using System;
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
                //TODO: Convert item to DailyWeatherRecord

                DailyWeatherRecord dailyWheatherRecord = new DailyWeatherRecord(new DateTime(2021, 8, 12), 22.0f, WeatherType.Mild);
                long unixDateTime = item.Value<long>("dt");
                dailyWheatherRecord.Day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;
                result.Add(dailyWheatherRecord);
            }

            return result;
        }

        // GET api/<WheatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
