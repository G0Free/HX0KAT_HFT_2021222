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
    public class StatLogic : IStatLogic
    {
        ICustomerRepository customerRepo;
        IPhoneRepository phoneRepo;
        IRepairerRepository repairerRepo;       

        public StatLogic(ICustomerRepository customerRepo, IPhoneRepository phoneRepo, IRepairerRepository repairerRepo)
        {
            this.customerRepo = customerRepo;
            this.phoneRepo = phoneRepo;
            this.repairerRepo = repairerRepo;
        } 

        /// <summary>
        /// Which Customer payed the most summerized, and the summerized cost
        /// </summary>
        /// <returns>The Customer and total paid amount</returns>
        public KeyValuePair<Customer, double> CustomerWithHighestPriceSummed()
        {
            var q = from x in phoneRepo.ReadAll()
                    group x by x.CustomerId into g
                    select new KeyValuePair<int, double>
                    (g.Key, g.Sum(c => c.Price) ?? 0);
            
            List<KeyValuePair<Customer, double>> result = new List<KeyValuePair<Customer, double>>();
            foreach (var item in q)
            {
                KeyValuePair<Customer, double> it = new KeyValuePair<Customer, double>(customerRepo.Read(item.Key), item.Value);
                result.Add(it);
            }
            result = result.OrderByDescending(x => x.Value).ToList();

            return result.FirstOrDefault();            
        }

        /// <summary>
        /// Which Customer payed the least summerized, and the summerized cost
        /// </summary>
        /// <returns>The Customer and total paid amount</returns>
        public KeyValuePair<Customer, double> CustomerWithLowestPriceSummed()
        {
            var q = from x in phoneRepo.ReadAll()
                    group x by x.CustomerId into g
                    select new KeyValuePair<int, double>
                    (g.Key, g.Sum(c => c.Price) ?? 0);            

            List<KeyValuePair<Customer, double>> result = new List<KeyValuePair<Customer, double>>();
            foreach (var item in q)
            {
                KeyValuePair<Customer, double> it = new KeyValuePair<Customer, double>(customerRepo.Read(item.Key), item.Value);
                result.Add(it);
            }
            result = result.OrderBy(x => x.Value).ToList();
           
            return result.FirstOrDefault();
        }

        public IEnumerable<Phone> AllPhonesByTheGivenRepairer(int givenRepairerId)
        {
            var q = from phone in phoneRepo.ReadAll()
                    where phone.RepairerId == givenRepairerId
                    select phone;

            return q;
        }

        public IEnumerable<Customer> AllCustomerByTheGivenRepairer(int givenRepairerId)
        {
            var q = from phone in phoneRepo.ReadAll()
                    where phone.RepairerId == givenRepairerId
                    select phone;
            //var result = from customer in customerRepo.ReadAll()
            //             where q.FirstOrDefault(y => y.CustomerId == customer.Id)
            //             select customer;

            var result = from phone in q
                         select phone.Customer;

            return result;
        }

    }
}
