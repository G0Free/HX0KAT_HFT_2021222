using HX0KAT_HFT_2021222.DataAccess.Data;
using HX0KAT_HFT_2021222.DataAccess.Interfaces;
using HX0KAT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(PhoneShopDbContext ctx) : base(ctx)
        {            
        }

        public void UpdateEmail(int id, string newEmail)
        {
            Customer old = Read(id);
            old.Email = newEmail;
            ctx.SaveChanges();
        }
    }
}
