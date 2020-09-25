using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWS;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace TerraformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerraformController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly ", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public TerraformController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string paramsObject)
        {
            var data = paramsObject;
            return "";
        }

        //[HttpGet]
        //public string dsdset1(int providerId, string[] resourcenames)
        //{
        //    try
        //    {
        //        AWS.Resources resources1 = new Resources();
        //        var resourcescript = resources1.GetScript(providerId, resourcenames);
        //        StringBuilder resourceScripts = new StringBuilder();
        //        resourceScripts.Append(resourcescript);
               
        //        return resourceScripts.ToString();
        //    }
        //    catch (Exception Ex)
        //    {

        //        return Ex.Message;
        //    }

        //}
    }
}