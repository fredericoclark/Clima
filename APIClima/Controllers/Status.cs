using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Measurements;
using Actor1.Interfaces;


namespace APIClima.Controllers
{
    [Route("api/status")]
    public class StatusController : Controller
    {


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{regiao}/{mac}")]
        //public async Task<string> GetStatus(string regiao, string mac)
        public string GetStatus(string regiao, string mac)
        {

            return "regiao: " + regiao + "mac: " + mac;
        }


    }
}
