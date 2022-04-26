using HX0KAT_HFT_2021222.Logic.Interfaces;
using HX0KAT_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HX0KAT_HFT_2021222.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        IPhoneLogic pl;

        public PhoneController(IPhoneLogic pl)
        {
            this.pl = pl;
        }

        // GET: api/<PhoneController>
        [HttpGet]
        public IEnumerable<Phone> ReadAll()
        {
            return pl.ReadAll();
        }

        // GET api/<PhoneController>/5
        [HttpGet("{id}")]
        public Phone Read(int id)
        {
            return pl.Read(id);
        }

        // POST api/<PhoneController>
        [HttpPost]
        public void Post([FromBody] Phone phone)
        {
            pl.Create(phone);
        }

        // PUT api/<PhoneController>
        [HttpPut]
        public void Update([FromBody] Phone phone)
        {
            pl.Update(phone);
        }

        // DELETE api/<PhoneController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
