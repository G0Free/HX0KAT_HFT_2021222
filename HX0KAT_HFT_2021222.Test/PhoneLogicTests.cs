using HX0KAT_HFT_2021222.DataAccess.Interfaces;
using HX0KAT_HFT_2021222.Logic.Services;
using HX0KAT_HFT_2021222.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.Test
{
    [TestFixture]
    public class PhoneLogicTests
    {
        public PhoneLogic PhoneLogic { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<IPhoneRepository> mockedPhoneRepo = new Mock<IPhoneRepository>();
            Mock<IRepairerRepository> mockedRepairerRepo = new Mock<IRepairerRepository>();
            Mock<ICustomerRepository> mockedCustomerRepo = new Mock<ICustomerRepository>();

            mockedPhoneRepo.Setup(x => x.ReadAll()).Returns(this.FakePhoneObjects);
            mockedRepairerRepo.Setup(x => x.ReadAll()).Returns(this.FakeRepairerObjects);
            mockedCustomerRepo.Setup(x => x.ReadAll()).Returns(this.FakeCustomerObjects);

            this.PhoneLogic = new PhoneLogic(mockedPhoneRepo.Object, mockedCustomerRepo.Object, mockedRepairerRepo.Object);
        }

        #region TESTS

        [TestCase(87400)]
        public void AVGPrice_ReturnsCorrectNumber(int expected)
        {
            Assert.That(this.PhoneLogic.AVGPrice(), Is.EqualTo(expected));
        }

        [TestCase("Apple",2)]
        public void GetAllPhonesWithASpecificBrand_ReturnsCorrectNumberOfItems(string brandname, int expectedNumber)
        {
            Assert.That(this.PhoneLogic.GetAllPhonesWithASpecificBrand(brandname).Count, Is.EqualTo(expectedNumber));
        }


        [TestCase(5)]
        public void ReadAll_ReturnsExactNumberOfInstances(int expected)
        {
            Assert.That(this.PhoneLogic.ReadAll().Count, Is.EqualTo(expected));
        }

        [Test]
        public void Read_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => PhoneLogic.Read(int.MaxValue));
        }

        #endregion

        #region FAKE_OBJECTS
        private IQueryable<Phone> FakePhoneObjects()
        {
            //sample data            
            #region Phones            
            Phone phone1 = new Phone() { Id = 1, Brand = "Apple", Model = "iPhone 11", Price = 100000 };
            Phone phone2 = new Phone() { Id = 2, Brand = "Samsung", Model = "Galaxy S11", Price = 85000 };
            Phone phone3 = new Phone() { Id = 3, Brand = "OnePlus", Model = "5T", Price = 92000 };
            Phone phone4 = new Phone() { Id = 4, Brand = "Huawei", Model = "P11", Price = 80000 };
            Phone phone5 = new Phone() { Id = 5, Brand = "Apple", Model = "iPhone 10", Price = 80000 };
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

            List<Phone> items = new List<Phone>();
            items.Add(phone1);
            items.Add(phone2);
            items.Add(phone3);
            items.Add(phone4);
            items.Add(phone5);

            return items.AsQueryable();
        }

        private IQueryable<Repairer> FakeRepairerObjects()
        {
            //sample data            
            #region Phones            
            Phone phone1 = new Phone() { Id = 1, Brand = "Apple", Model = "iPhone 11", Price = 100000 };
            Phone phone2 = new Phone() { Id = 2, Brand = "Samsung", Model = "Galaxy S11", Price = 85000 };
            Phone phone3 = new Phone() { Id = 3, Brand = "OnePlus", Model = "5T", Price = 92000 };
            Phone phone4 = new Phone() { Id = 4, Brand = "Huawei", Model = "P11", Price = 80000 };
            Phone phone5 = new Phone() { Id = 5, Brand = "Apple", Model = "iPhone 10", Price = 80000 };
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

            List<Repairer> items = new List<Repairer>();
            items.Add(repairer1);
            items.Add(repairer2);
            items.Add(repairer3);

            return items.AsQueryable();
        }

        private IQueryable<Customer> FakeCustomerObjects()
        {
            //sample data            
            #region Phones            
            Phone phone1 = new Phone() { Id = 1, Brand = "Apple", Model = "iPhone 11", Price = 100000 };
            Phone phone2 = new Phone() { Id = 2, Brand = "Samsung", Model = "Galaxy S11", Price = 85000 };
            Phone phone3 = new Phone() { Id = 3, Brand = "OnePlus", Model = "5T", Price = 92000 };
            Phone phone4 = new Phone() { Id = 4, Brand = "Huawei", Model = "P11", Price = 80000 };
            Phone phone5 = new Phone() { Id = 5, Brand = "Apple", Model = "iPhone 10", Price = 80000 };
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

            List<Customer> items = new List<Customer>();
            items.Add(customer1);
            items.Add(customer2);
            items.Add(customer3);

            return items.AsQueryable();
        }

        #endregion
    }
}
