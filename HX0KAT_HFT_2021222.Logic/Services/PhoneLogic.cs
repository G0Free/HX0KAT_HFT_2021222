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
    public class PhoneLogic : IPhoneLogic
    {
        IPhoneRepository phoneRepo;

        ICustomerRepository customerRepo;
        IRepairerRepository repairerRepo;

        public PhoneLogic(IPhoneRepository phoneRepo)
        {
            this.phoneRepo = phoneRepo;
        }

        public PhoneLogic(IPhoneRepository phoneRepo, ICustomerRepository customerRepo, IRepairerRepository repairerRepo) : this(phoneRepo)
        {
            this.customerRepo = customerRepo;
            this.repairerRepo = repairerRepo;
        }



        #region CRUD

        public void Create(Phone phone)
        {
            phoneRepo.Create(phone);
        }

        public void Delete(int id)
        {
            phoneRepo.Delete(id);
        }

        public Phone Read(int id)
        {
            return phoneRepo.Read(id) ?? throw new ArgumentException("Phone with the specified ID does not exists");
        }

        public IEnumerable<Phone> ReadAll()
        {
            return phoneRepo.ReadAll();
        }

        public void Update(Phone phone)
        {
            phoneRepo.Update(phone);
        }

        #endregion

        #region NON-CRUD

        public IEnumerable<double> AVGPrice()
        {
            var q = new List<double>();
            q.Add(phoneRepo.ReadAll().Average(p => p.Price) ?? -1);
            return q;
        }

        public IEnumerable<Phone> GetAllPhonesWithASpecificBrand(string brandName)
        {
            var q = from phone in phoneRepo.ReadAll()
                    where phone.Brand.ToString().Contains(brandName)
                    select phone;
            return q;
        }        

        #endregion
    }
}
