using HX0KAT_HFT_2021222.Logic.Interfaces;
using HX0KAT_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace HX0KAT_HFT_2021222.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPhoneLogic pl;
        ICustomerLogic cl;
        IRepairerLogic rl;

        public StatController(IPhoneLogic pl, ICustomerLogic cl, IRepairerLogic rl)
        {
            this.pl = pl;
            this.cl = cl;
            this.rl = rl;
        }
        #region phone
        [HttpGet]
        public double PhoneAVGPrice()
        {
            return pl.AVGPrice();
        }

        [HttpGet]
        public IEnumerable<Phone> PhoneGetAllPhonesWithASpecificBrand(string brand)
        {
            return pl.GetAllPhonesWithASpecificBrand(brand);
        }
        #endregion

        #region customer
        [HttpGet]
        public IEnumerable<Customer> CustomerGetAllCustomersWithSameFirstName(string firstName)
        {
           return cl.GetAllCustomersWithSameFirstName(firstName);
        }
        [HttpGet]
        public IEnumerable<Customer> CustomerGetAllCustomersWithSameLastName(string lastName)
        {
            return cl.GetAllCustomersWithSameLastName(lastName);            
        }
        #endregion

        #region repairer
        [HttpGet]
        public IEnumerable<Repairer> RepairerGetAllRepairerWithSameFirstName(string firstName)
        {
            return rl.GetAllRepairerWithSameFirstName(firstName);
        }
        [HttpGet]
        public IEnumerable<Repairer> RepairerGetAllRepairerWithSameLastName(string lastName)
        {
            return rl.GetAllRepairerWithSameLastName(lastName);
        }
        #endregion


    }
}
