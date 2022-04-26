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
            modelBuilder.Entity<Customer>(entity =>
            {
                entity
                .HasMany(customer => customer.Phone)
                .WithOne(phone => phone.Customer)
                //.HasForeignKey(customer => customer.PhoneId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Repairer>(entity =>
            {
                entity
                .HasMany(repairer => repairer.Phones)
                .WithOne(phone => phone.Repairer)
                .HasForeignKey(phone => phone.RepairerId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            //sample data            
            #region Phones            
            Phone phone1 = new Phone() { Id = 1, Brand = Brand.Apple, Model = "iPhone 11", Price = 100000 };
            Phone phone2 = new Phone() { Id = 2, Brand = Brand.Samsung, Model = "Galaxy S11", Price = 85000 };
            Phone phone3 = new Phone() { Id = 3, Brand = Brand.OnePlus, Model = "5T", Price = 92000 };
            Phone phone4 = new Phone() { Id = 4, Brand = Brand.Huawei, Model = "P11", Price = 80000 };
            Phone phone5 = new Phone() { Id = 5, Brand = Brand.Apple, Model = "iPhone 10", Price = 80000 };
            #endregion

            #region Customers

            Customer customer1 = new Customer() { Id = 1, FirstName = "Eliot", LastName = "Alderson", Email = "eliot.alderson@gmail.com" };
            Customer customer2 = new Customer() { Id = 2, FirstName = "Lewis", LastName = "Hamilton", Email = "lewis.hamilton@gmail.com" };
            Customer customer3 = new Customer() { Id = 3, FirstName = "Eliot", LastName = "Shelby", Email = "eliot.shelby@gmail.com" };

            #endregion

            #region Repairers

            Repairer repairer1 = new Repairer() { Id = 1, FirstName = "George", LastName = "Lucas" };
            Repairer repairer2 = new Repairer() { Id = 2, FirstName = "John", LastName = "Glass" };
            Repairer repairer3 = new Repairer() { Id = 3, FirstName = "Joey", LastName = "Tribbiani" };

            #endregion


            #region ForeignKeysSet
            //customer1.PhoneId = phone1.Id;
            //customer2.PhoneId = phone2.Id;
            //customer3.PhoneId = phone3.Id;

            phone1.CustomerId = customer1.Id;
            phone2.CustomerId = customer2.Id;
            phone3.CustomerId = customer3.Id;
            phone4.CustomerId = customer1.Id;
            phone5.CustomerId = customer2.Id;

            phone1.RepairerId = repairer1.Id;
            phone2.RepairerId = repairer1.Id;
            phone3.RepairerId = repairer2.Id;
            phone4.RepairerId = repairer3.Id;
            phone5.RepairerId = repairer3.Id;
            #endregion

            modelBuilder.Entity<Phone>().HasData(phone1, phone2, phone3, phone4, phone5);
            modelBuilder.Entity<Customer>().HasData(customer1, customer2, customer3);
            modelBuilder.Entity<Repairer>().HasData(repairer1, repairer2, repairer3);
        }
    }
}
