using HX0KAT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.Logic.Interfaces
{
    public interface ICustomerLogic
    {
        void Create(Customer customer);
        Customer Read(int id);
        IEnumerable<Customer> ReadAll();
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
