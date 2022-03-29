﻿using HX0KAT_HFT_2021222.Models;
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
            //modelBuilder.Entity<Customer>(entity =>
            //{
            //    entity
            //    .HasOne(customer => customer.Phone)
            //    //.WithOne(phone => phone.Customer)
            //    .HasForeignKey(customer => customer.PhoneId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //});

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

            Phone phone1 = new Phone() { Id = 1, Brand = Brand.Apple, Model = "iPhone 11" };
            Phone phone2 = new Phone() { Id = 2, Brand = Brand.Samsung, Model = "Galaxy S11" };
            Phone phone3 = new Phone() { Id = 3, Brand = Brand.OnePlus, Model = "5T" };
            Phone phone4 = new Phone() { Id = 4, Brand = Brand.Huawei, Model = "P11" };

            #endregion

            #region Customers

            Customer customer1 = new Customer() { Id = 1, FirstName = "Eliot", LastName = "Alderson", Email = "eliot.alderson@gmail.com", PhoneId = 1 };
            Customer customer2 = new Customer() { Id = 2, FirstName = "Lewis", LastName = "Hamilton", Email = "lewis.hamilton@gmail.com", PhoneId = 2 };
            Customer customer3 = new Customer() { Id = 3, FirstName = "Clive", LastName = "Shelby", Email = "clive.shelby@gmail.com", PhoneId = 3 };

            #endregion

            #region Repairers

            Repairer repairer1 = new Repairer() { Id = 1, FirstName = "George", LastName = "Lucas" };
            Repairer repairer2 = new Repairer() { Id = 1, FirstName = "John", LastName = "Glass" };
            Repairer repairer3 = new Repairer() { Id = 1, FirstName = "Joey", LastName = "Tribbiani" };

            #endregion
        }
    }
}