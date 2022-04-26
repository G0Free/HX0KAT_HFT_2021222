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
    public class RepairerLogic : IRepairerLogic
    {
        IRepairerRepository repairerRepo;

        IPhoneRepository phoneRepo;
        ICustomerRepository customerRepo;

        public RepairerLogic(IRepairerRepository repairerRepo)
        {
            this.repairerRepo = repairerRepo;
        }

        public RepairerLogic(IRepairerRepository repairerRepo, IPhoneRepository phoneRepo, ICustomerRepository customerRepo) : this(repairerRepo)
        {
            this.phoneRepo = phoneRepo;
            this.customerRepo = customerRepo;
        }



        #region CRUD

        public void Create(Repairer repairer)
        {
            repairerRepo.Create(repairer);
        }

        public void Delete(int id)
        {
            repairerRepo.Delete(id);
        }

        public Repairer Read(int id)
        {
            return repairerRepo.Read(id) ?? throw new ArgumentException("Repairer with the specified id does not exists.");
        }

        public IEnumerable<Repairer> ReadAll()
        {
            return repairerRepo.ReadAll();
        }

        public void Update(Repairer repairer)
        {
            repairerRepo.Update(repairer);
        }

        #endregion

        #region NON-CRUD

        public IEnumerable<Repairer> GetAllRepairerWithSameFirstName(string firstName)
        {
            var q = from x in repairerRepo.ReadAll()
                    where x.FirstName.Contains(firstName)
                    select x;

            return q;
        }

        public IEnumerable<Repairer> GetAllRepairerWithSameLastName(string lastName)
        {
            var q = from x in repairerRepo.ReadAll()
                    where x.LastName.Contains(lastName)
                    select x;

            return q;
        }

        #endregion
    }
}
