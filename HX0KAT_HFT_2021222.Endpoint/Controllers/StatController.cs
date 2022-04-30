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
        IStatLogic stat;

        public StatController(IPhoneLogic pl, ICustomerLogic cl, IRepairerLogic rl, IStatLogic stat)
        {
            this.pl = pl;
            this.cl = cl;
            this.rl = rl;
            this.stat = stat;
        }
        #region phone
        [HttpGet]
        public IEnumerable<double> PhoneAVGPrice()
        {            
            return pl.AVGPrice();
        }

        [HttpGet("{brand}")]
        public IEnumerable<Phone> PhoneGetAllPhonesWithASpecificBrand(string brand)
        {
            return pl.GetAllPhonesWithASpecificBrand(brand);
        }
        #endregion

        #region customer
        [HttpGet("{firstName}")]
        public IEnumerable<Customer> CustomerGetAllCustomersWithSameFirstName(string firstName)
        {
           return cl.GetAllCustomersWithSameFirstName(firstName);
        }
        [HttpGet("{lastName}")]
        public IEnumerable<Customer> CustomerGetAllCustomersWithSameLastName(string lastName)
        {
            return cl.GetAllCustomersWithSameLastName(lastName);
        }
        #endregion

        #region repairer
        [HttpGet("{firstname}")]
        public IEnumerable<Repairer> RepairerGetAllRepairerWithSameFirstName(string firstName)
        {
            return rl.GetAllRepairerWithSameFirstName(firstName);
        }
        [HttpGet("{lastname}")]
        public IEnumerable<Repairer> RepairerGetAllRepairerWithSameLastName(string lastName)
        {
            return rl.GetAllRepairerWithSameLastName(lastName);
        }
        #endregion

        #region stat
        [HttpGet]
        public KeyValuePair<Customer, double> CustomerWithHighestPriceSummed()
        {
            return stat.CustomerWithHighestPriceSummed();
        }

        [HttpGet]
        public KeyValuePair<Customer, double> CustomerWithLowestPriceSummed()
        {
            return stat.CustomerWithLowestPriceSummed();
        }

        [HttpGet("{givenRepairerId}")]
        public IEnumerable<Phone> AllPhonesByTheGivenRepairer(int givenRepairerId)
        {
            return stat.AllPhonesByTheGivenRepairer(givenRepairerId);
        }

        [HttpGet("{givenRepairerId}")]
        public IEnumerable<Customer> AllCustomerByTheGivenRepairer(int givenRepairerId)
        {
            return stat.AllCustomerByTheGivenRepairer(givenRepairerId);
        }

        #endregion

    }
}
