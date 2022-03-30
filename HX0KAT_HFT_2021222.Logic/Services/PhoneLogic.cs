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

        public PhoneLogic(IPhoneRepository phoneRepo)
        {
            this.phoneRepo = phoneRepo;
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



        #endregion
    }
}
