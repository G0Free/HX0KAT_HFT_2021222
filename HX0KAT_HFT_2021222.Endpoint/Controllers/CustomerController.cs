using HX0KAT_HFT_2021222.Logic.Interfaces;
using HX0KAT_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HX0KAT_HFT_2021222.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic cl;

        public CustomerController(ICustomerLogic cl)
        {
            this.cl = cl;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Read()
        {
            return cl.ReadAll();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Read(int id)
        {
            return cl.Read(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            cl.Create(customer);
        }

        // PUT api/<CustomerController>
        [HttpPut]
        public void Update([FromBody] Customer customer)
        {
            cl.Update(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
