using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using AWS;

namespace TerraformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly ", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController()
        {
            
        }
        public string GetScript(int providerId, string[] resourcenames)
        {
            try
            {
                StringBuilder resourceScripts = new StringBuilder();
                LoadFile();
                var resources = GetResourceScript();

                if (providerId == 1)
                {

                    foreach (AWSResources resource in resources)
                    {
                        if (resourcenames[0].ToString() == resource.resourceName)
                        {
                            resourceScripts.Append(resource.resourceScript);
                        }


                    }
                }

                return resourceScripts.ToString();
            }
            catch (Exception Ex)
            {

                return Ex.Message;
            }
            //Process JSOn File
            //if (enumAWSReources.re)
        }
        private List<AWSResources> GetResourceScript()
        {
            try
            {

                using (StreamReader r = new StreamReader("awsresource.json"))
                {
                    string json = r.ReadToEnd();
                    List<AWSResources> resources = JsonConvert.DeserializeObject<List<AWSResources>>(json);
                    return resources;
                }

            }
            catch (Exception Ex)
            {
                string error = Ex.Message;
                return null;
            }
        }
        private void LoadFile()
        {
            try
            {

                using (StreamReader r = new StreamReader("awsresource.json"))
                {
                    string json = r.ReadToEnd();
                    List<AWSResources> resources = JsonConvert.DeserializeObject<List<AWSResources>>(json);
                }

            }
            catch (Exception Ex)
            {
                string error = Ex.Message;
            }
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}