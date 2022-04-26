using HX0KAT_HFT_2021222.Logic.Interfaces;
using HX0KAT_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HX0KAT_HFT_2021222.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairerController : ControllerBase
    {
        IRepairerLogic rl;

        public RepairerController(IRepairerLogic rl)
        {
            this.rl = rl;
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
        }

        // PUT api/<RepairerController>
        [HttpPut]
        public void Update([FromBody] Repairer repairer)
        {
            rl.Update(repairer);
        }

        // DELETE api/<RepairerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rl.Delete(id);
        }
    }
}
