﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string latitude = "46.7700";
        private readonly string longitude = "23.5800";
        private readonly string apiKey = "f01d52e552796a854eb758d8fb3c04d3";

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

        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);
            List<DailyWeatherRecord> result = new List<DailyWeatherRecord>();

            var jsonArray = json["daily"].Take(7);

            foreach (var item in jsonArray)
            {
                DailyWeatherRecord dailyWheatherRecord = new DailyWeatherRecord();
                long unixDateTime = item.Value<long>("dt");
                dailyWheatherRecord.Day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;
                result.Add(dailyWheatherRecord);

                float temperature = item.SelectToken("temp").Value<float>("day");
                temperature = temperature - 272.15f;
                dailyWheatherRecord.Temperature = temperature;

                string weather = item.SelectToken("weather")[0].Value<string>("description");
                dailyWheatherRecord.Type = Convert(weather);
            }

            return result;
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
                default:
                    throw new Exception($"Unknown weather type {weather}.");
            }
        }

        // GET api/<WheatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
