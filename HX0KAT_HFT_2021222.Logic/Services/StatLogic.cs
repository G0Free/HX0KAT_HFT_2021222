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
        //IPhoneLogic phoneLogic;
        //ICustomerLogic customerLogic;
        //IRepairerLogic repairerLogic;

        ICustomerRepository customerRepo;
        IPhoneRepository phoneRepo;
        IRepairerRepository repairerRepo;

        //public StatLogic(IPhoneLogic phoneLogic, ICustomerLogic customerLogic, IRepairerLogic repairerLogic)
        //{
        //    this.phoneLogic = phoneLogic;
        //    this.customerLogic = customerLogic;
        //    this.repairerLogic = repairerLogic;
        //}

        public StatLogic(ICustomerRepository customerRepo, IPhoneRepository phoneRepo, IRepairerRepository repairerRepo)
        {
            this.customerRepo = customerRepo;
            this.phoneRepo = phoneRepo;
            this.repairerRepo = repairerRepo;
        }

        //Melyik customer vásárolt összesen a legnagyobb értékben és mennyibe került összesen
        //Which Customer payed the most summerized, and the summerized cost
        //public KeyValuePair<Customer, double> CustomerWithHighestPriceSummed()
        //{
        //    var q = from x in phoneLogic.ReadAll()
        //            group x by x.CustomerId into g
        //            select new KeyValuePair<int, double>
        //            (g.Key ,g.Sum(c => c.Price) ?? 0);

        //    q.OrderBy(x => x.Value);

        //    List<KeyValuePair<Customer, double>> result = new List<KeyValuePair<Customer, double>>();
        //    foreach (var item in q)
        //    {
        //        KeyValuePair<Customer,double> it = new KeyValuePair<Customer,double>(customerLogic.Read(item.Key), item.Value);
        //        result.Add(it);
        //    }

        //    return result.FirstOrDefault();
        //}


        //---
        public KeyValuePair<Customer, double> CustomerWithHighestPriceSummed()
        {
            var q = from x in phoneRepo.ReadAll()
                    group x by x.CustomerId into g
                    select new KeyValuePair<int, double>
                    (g.Key, g.Sum(c => c.Price) ?? 0);

            q.OrderBy(x => x.Value);
            
            List<KeyValuePair<Customer, double>> result = new List<KeyValuePair<Customer, double>>();
            foreach (var item in q)
            {
                KeyValuePair<Customer, double> it = new KeyValuePair<Customer, double>(customerRepo.Read(item.Key), item.Value);
                result.Add(it);
            }

            return result.FirstOrDefault();
        }

        public IEnumerable<Phone> AllPhonesByTheGivenRepairer(int givenRepairerId)
        {
            var q = from phone in phoneRepo.ReadAll()
                    where phone.RepairerId == givenRepairerId
                    select phone;

            return q;
        }
    }
}
