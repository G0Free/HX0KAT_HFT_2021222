using HX0KAT_HFT_2021222.Endpoint.Services;
using HX0KAT_HFT_2021222.Logic.Interfaces;
using HX0KAT_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HX0KAT_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepairerController : ControllerBase
    {
        IRepairerLogic rl;
        IHubContext<SignalRHub> hub;

        public RepairerController(IRepairerLogic rl, IHubContext<SignalRHub> hub)
        {
            this.rl = rl;
            this.hub = hub;
        }

        // GET: api/<RepairerController>
        [HttpGet]
        public IEnumerable<Repairer> ReadAll()
        {
            return rl.ReadAll();
        }

        // GET api/<RepairerController>/5
        [HttpGet("{id}")]
        public Repairer Read(int id)
        {
            return rl.Read(id);
        }

        // POST api/<RepairerController>
        [HttpPost]
        public void Post([FromBody] Repairer repairer)
        {
            rl.Create(repairer);
            this.hub.Clients.All.SendAsync("RepairerCreated", repairer);
        }

        // PUT api/<RepairerController>
        [HttpPut]
        public void Update([FromBody] Repairer repairer)
        {
            rl.Update(repairer);
            this.hub.Clients.All.SendAsync("RepairerUpdated", repairer);
        }

        // DELETE api/<RepairerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var repairerToDelete = this.rl.Read(id);
            rl.Delete(id);
            this.hub.Clients.All.SendAsync("RepairerDeleted", repairerToDelete);
        }
    }
}
