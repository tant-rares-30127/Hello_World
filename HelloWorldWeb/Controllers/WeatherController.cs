// <copyright file="WeatherController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace HelloWorldWeb.Controllers
{
    /// <summary>
    /// Fetch data from weather API.
    /// <see href="https://openweathermap.org/api" />.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private const float KELVIN_CONST = 273.15f;

        private readonly string latitude;
        private readonly string longitude;
        private readonly string apiKey;

        public WeatherController(IWeatherControllerSettings conf)
        {
            longitude = conf.Longitude;
            latitude = conf.Latitude;
            apiKey = conf.ApiKey;
        }

        // GET: api/<WheatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            // https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.5800&exclude=hourly,minutely&appid=f01d52e552796a854eb758d8fb3c04d3
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return this.ConvertResponseToWeatherRecordList(response.Content);
        }

        [NonAction]
        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);
            if (json["daily"] == null)
            {
                throw new Exception("Apikey not valid.");
            }

            var jsonArray = json["daily"].Take(7);
            return jsonArray.Select(CreatingWeatherRecordFromJToken);
        }

        private DailyWeatherRecord CreatingWeatherRecordFromJToken(JToken item)
        {
            long unixDateTime = item.Value<long>("dt");
            var day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;

            float temperature = item.SelectToken("temp").Value<float>("day");
            temperature = temperature - KELVIN_CONST;

            string weather = item.SelectToken("weather")[0].Value<string>("description");
            var type = Convert(weather);

            DailyWeatherRecord dailyWheatherRecord = new DailyWeatherRecord(day, temperature, type);
            return dailyWheatherRecord;
        }

        private WeatherType Convert(string weather)
        {
            switch (weather)
            {
                case "few clouds":
                    return WeatherType.FewClouds;
                case "light rain":
                    return WeatherType.LightRain;
                case "broken clouds":
                    return WeatherType.BrokenClouds;
                case "clear sky":
                    return WeatherType.ClearSky;
                case "scattered clouds":
                    return WeatherType.ScatteredClouds;
                case "shower rain":
                    return WeatherType.ShowerRain;
                case "rain":
                    return WeatherType.Rain;
                case "thunderstorm":
                    return WeatherType.Thunderstorm;
                case "snow":
                    return WeatherType.Snow;
                case "mist":
                    return WeatherType.Mist;
                case "moderate rain":
                    return WeatherType.ModerateRain;
                case "overcast clouds":
                    return WeatherType.OvercastClouds;
                default:
                    throw new Exception($"Unknown weather type {weather}.");
            }
        }

        /// <summary>
        /// Get a weather forcast for the day in specified amount of days from now.
        /// </summary>
        /// <param name="index">Amount of days from now (from 0-7).</param>
        /// <returns>The weather forecast.</returns>
        [HttpGet("{index}")]
        public string Get(int index)
        {
            return "value";
        }
    }
}
