using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // GET: api/<WheatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            return new DailyWeatherRecord[]
            {
                new DailyWeatherRecord(new DateTime(2021, 8, 12), 22, WeatherType.Mild),
                new DailyWeatherRecord(new DateTime(2021, 8, 13), 25, WeatherType.Hot),
            };
        }

        // GET api/<WheatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WheatherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WheatherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WheatherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
