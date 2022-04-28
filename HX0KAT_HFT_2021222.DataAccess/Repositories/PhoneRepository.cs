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
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(PhoneShopDbContext ctx) : base(ctx)
        {
        }

        public void UpdateBrand(int id, string newBrand)
        {
            Phone old = Read(id);
            old.Brand = newBrand;
            ctx.SaveChanges();
        }

        public void UpdateModel(int id, string newModel)
        {
            Phone old = Read(id);
            old.Model = newModel;
            ctx.SaveChanges();
        }

        public void UpdatePrice(int id, int newPrice)
        {
            Phone old = Read(id);
            old.Price = newPrice;
            ctx.SaveChanges();
        }
    }
}
