using HX0KAT_HFT_2021222.DataAccess.Interfaces;
using HX0KAT_HFT_2021222.Logic.Interfaces;
using HX0KAT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.Logic.Services
{
    public class CustomerLogic : ICustomerLogic
    {
        ICustomerRepository customerRepo;

        public CustomerLogic(ICustomerRepository customerRepository)
        {
            this.customerRepo = customerRepository;
        }

        #region CRUD
        public void Create(Customer customer)
        {
            customerRepo.Create(customer);
        }

        public void Delete(int id)
        {
            customerRepo.Delete(id);
        }

        public Customer Read(int id)
        {
            return customerRepo.Read(id) ?? throw new ArgumentException("Customer with the specified ID does not exists");
        }

        public IEnumerable<Customer> ReadAll()
        {
            return customerRepo.ReadAll();
        }

        public void Update(Customer customer)
        {
            customerRepo.Update(customer);
        }
        #endregion

        #region NON-CRUD



        #endregion
    }
}
