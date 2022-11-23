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
    public class CustomerController : ControllerBase
    {
        ICustomerLogic cl;
        IHubContext<SignalRHub> hub;

        public CustomerController(ICustomerLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> ReadAll()
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
            this.hub.Clients.All.SendAsync("CustomerCreated", customer);
        }

        // PUT api/<CustomerController>
        [HttpPut]
        public void Update([FromBody] Customer customer)
        {
            cl.Update(customer);
            this.hub.Clients.All.SendAsync("CustomerUpdated", customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customerToDelete = this.cl.Read(id);
            cl.Delete(id);
            this.hub.Clients.All.SendAsync("CustomerDeleted", customerToDelete);
        }
    }
}
