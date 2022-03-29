using HX0KAT_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.DataAccess.Data
{
    public class PhoneShopDbContext : DbContext
    {


        public PhoneShopDbContext()
        {
            this.Database.EnsureCreated();
        }

        public PhoneShopDbContext(DbContextOptions<PhoneShopDbContext> options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseInMemoryDatabase("phoneshopdb")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(); //NOT DONE

            modelBuilder.Entity<Customer>(); //NOT DONE

            modelBuilder.Entity<Repairer>(); //NOT DONE


        }
    }
}
