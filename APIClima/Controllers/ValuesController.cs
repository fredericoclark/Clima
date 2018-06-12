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

namespace API_ACN.Controllers
{


    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        //[HttpGet("{mac}/{regiao}/{temperatura}/{umidade}/{chuvas}/{chuvai}/{ip}")]
        [HttpGet("{mac}/{regiao}/{temperatura}/{umidade}/{chuvas}/{chuvai}/{ip}")]
        public async Task<string> GetVsAsync(string mac, string regiao, float temperatura, float umidade, string chuvas, string chuvai, string ip)
        {
            Medicoes medicoes = new Medicoes
            {
                MAC = mac,
                REGIAO = regiao,
                TEMP = temperatura,
                UMIDADE = umidade,
                CHUVAS = chuvas,
                CHUVAI = chuvai,
                IP = ip
            };

            var actor = ActorProxy.Create<IMet>(new ActorId(1), new Uri("fabric:/Clima/MetActorService"));

            try
            {
                await actor.EnviaMedicoes(medicoes);
            }
            catch (Exception e)
            {
                //ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }




            return " mac: " + mac + " região: " + regiao + " temperatura: " + temperatura + " umidade " + umidade + " chuvas " + chuvas + " chuvai " + chuvai + " ip " + ip;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
