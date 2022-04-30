using ConsoleTools;
using HX0KAT_HFT_2021222.Models;
using System;
using System.Threading;

namespace HX0KAT_HFT_2021222.Client
{
    class Program
    {
        static RestService rserv;
        static void Main(string[] args)
        {
            //Thread.Sleep(8000);
            rserv = new RestService("http://localhost:5236/");

            var menu = new ConsoleMenu()
                .Add(">> LIST ALL PHONES", () => ListAllPhones(rserv))
                .Add(">> LIST ALL CUSTOMERS", () => ListAllCustomers(rserv))
                .Add(">> LIST ALL REPAIRER", () => ListAllRepairer(rserv))

                .Add(">> PHONE BY ID", () => PhoneById(rserv))
                .Add(">> CUSTOMER BY ID", () => CustomerById(rserv))
                .Add(">> REPAIRER BY ID", () => RepairerById(rserv))

                .Add(">> CREATE A PHONE", () => CreatePhone(rserv))
                .Add(">> CREATE A CUSTOMER", () => CreateCustomer(rserv))
                .Add(">> CREATE A REPAIRER", () => CreateRepairer(rserv))

                .Add(">> UPDATE A PHONE", () => UpdatePhone(rserv))
                .Add(">> UPDATE A CUSTOMER", () => UpdateCustomer(rserv))
                .Add(">> UPDATE A REPAIRER", () => UpdateRepairer(rserv))

                .Add(">> DELETE A PHONE", () => DeletePhone(rserv))
                .Add(">> DELETE A CUSTOMER", () => DeleteCustomer(rserv))
                .Add(">> DELETE A REPAIRER", () => DeleteRepairer(rserv))

                //phone
                .Add(">> AVERAGE PRICE", () => PhoneAVGPrice(rserv))
                .Add(">> PHONES WITH A SPECIFIC BRAND", () => PhoneGetAllPhonesWithASpecificBrand(rserv))

                //custmoer
                .Add(">> ALL CUSTOMERS WITH THE SAME FIRSTNAME", () => CustomerGetAllCustomersWithSameFirstName(rserv))
                .Add(">> ALL CUSTOMERS WITH THE SAME LASTNAME", () => CustomerGetAllCustomersWithSameLastName(rserv))

                //repairer
                .Add(">> ALL REPAIRER WITH THE SAME FIRSTNAME", () => RepairerGetAllRepairerWithSameFirstName(rserv))
                .Add(">> ALL REPAIRER WITH THE SAME LASTNAME", () => RepairerGetAllRepairerWithSameLastName(rserv))



                .Add(">> EXIT", ConsoleMenu.Close);


            menu.Show();
        }

        #region CRUD

        #region ReadAll
        private static void ListAllPhones(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: ALL PHONES  ::\n");

            var phones = rserv.Get<Phone>("api/phone");
            foreach (var item in phones)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void ListAllCustomers(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: ALL CUSTOMERS  ::\n");

            var customers = rserv.Get<Customer>("api/customer");
            foreach (var item in customers)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void ListAllRepairer(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: ALL REPAIRER  ::\n");

            var repairers = rserv.Get<Repairer>("api/repairer");
            foreach (var item in repairers)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }
        #endregion

        #region Read
        private static void PhoneById(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: PHONE BY ID ::\n");

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenItem = rserv.Get<Phone>(choosenId, "api/phone");
            Console.WriteLine(choosenItem.ToString());

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void CustomerById(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: CUSTOMER BY ID ::\n");

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenItem = rserv.Get<Customer>(choosenId, "api/customer");
            Console.WriteLine(choosenItem.ToString());

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void RepairerById(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: REPAIRER BY ID ::\n");

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenItem = rserv.Get<Repairer>(choosenId, "api/repairer");
            Console.WriteLine(choosenItem.ToString());

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }
        #endregion

        #region Create
        private static void CreatePhone(RestService rserv)
        {
            Console.Clear();

            Phone phone = new Phone();

            Console.WriteLine("Brand:");
            phone.Brand = Console.ReadLine();

            Console.WriteLine("Model:");
            phone.Model = Console.ReadLine();

            Console.WriteLine("Price");
            phone.Price = int.Parse(Console.ReadLine());

            Console.WriteLine("CustomerId:");
            phone.CustomerId = int.Parse(Console.ReadLine());

            Console.WriteLine("RepairerId:");
            phone.RepairerId = int.Parse(Console.ReadLine());

            rserv.Post<Phone>(phone, "api/phone");
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void CreateCustomer(RestService rserv)
        {
            Console.Clear();

            Customer customer = new Customer();

            Console.WriteLine("Firstname:");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("Lastname:");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("Email:");
            customer.Email = Console.ReadLine();

            rserv.Post<Customer>(customer, "api/customer");
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void CreateRepairer(RestService rserv)
        {
            Console.Clear();

            Repairer repairer = new Repairer();

            Console.WriteLine("Firstname:");
            repairer.FirstName = Console.ReadLine();

            Console.WriteLine("Lastname:");
            repairer.LastName = Console.ReadLine();

            rserv.Post<Repairer>(repairer, "api/repairer");
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }
        #endregion

        #region Update

        private static void UpdatePhone(RestService rserv)
        {
            Console.Clear();

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());
            Phone phone = rserv.Get<Phone>(choosenId, "api/phone");

            Console.WriteLine("Brand:");
            phone.Brand = Console.ReadLine();

            Console.WriteLine("Model:");
            phone.Model = Console.ReadLine();

            Console.WriteLine("Price");
            phone.Price = int.Parse(Console.ReadLine());

            Console.WriteLine("CustomerId:");
            phone.CustomerId = int.Parse(Console.ReadLine());

            Console.WriteLine("RepairerId:");
            phone.RepairerId = int.Parse(Console.ReadLine());

            rserv.Put<Phone>(phone, "api/phone");
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void UpdateCustomer(RestService rserv)
        {
            Console.Clear();

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());
            Customer customer = rserv.Get<Customer>(choosenId, "api/customer");

            Console.WriteLine("Firstname:");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("Lastname:");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("Email:");
            customer.Email = Console.ReadLine();

            rserv.Put<Customer>(customer, "api/customer");
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void UpdateRepairer(RestService rserv)
        {
            Console.Clear();

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());
            Repairer repairer = rserv.Get<Repairer>(choosenId, "api/repairer");

            Console.WriteLine("Firstname:");
            repairer.FirstName = Console.ReadLine();

            Console.WriteLine("Lastname:");
            repairer.LastName = Console.ReadLine();

            rserv.Put<Repairer>(repairer, "api/repairer");
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        #endregion

        #region Delete
        private static void DeletePhone(RestService rserv)
        {
            Console.Clear();

            ListAllPhones(rserv);

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenItem = rserv.Get<Phone>(choosenId, "api/phone");
            Console.WriteLine(choosenItem.ToString() + " got deleted");

            rserv.Delete(choosenId, "api/phone");

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void DeleteCustomer(RestService rserv)
        {
            Console.Clear();

            ListAllCustomers(rserv);

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenItem = rserv.Get<Customer>(choosenId, "api/customer");
            Console.WriteLine(choosenItem.ToString() + " got deleted");

            rserv.Delete(choosenId, "api/customer");

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void DeleteRepairer(RestService rserv)
        {
            Console.Clear();

            ListAllRepairer(rserv);

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenItem = rserv.Get<Repairer>(choosenId, "api/repairer");
            Console.WriteLine(choosenItem.ToString() + " got deleted");

            rserv.Delete(choosenId, "api/repairer");

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }
        #endregion

        #endregion

        #region NON_CRUD

        #region phone
        private static void PhoneAVGPrice(RestService rserv)
        {
            Console.Clear();
            var list = rserv.Get<double>("api/Stat/PhoneAVGPrice"); foreach (var item in list)
            {
                Console.WriteLine($"Avegrage price is: {item}");
            }            

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void PhoneGetAllPhonesWithASpecificBrand(RestService rserv)
        {
            Console.Clear();

            Console.WriteLine("Brand:");
            string choosenBrand = Console.ReadLine();
            var result = rserv.GetMultiple<Phone>(choosenBrand, "api/Stat/PhoneGetAllPhonesWithASpecificBrand");
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }
        #endregion

        #region customer
        private static void CustomerGetAllCustomersWithSameFirstName(RestService rserv)
        {
            Console.Clear();
            var list = rserv.Get<double>("api/Stat/CustomerGetAllCustomersWithSameFirstName"); foreach (var item in list)
            {
                Console.WriteLine($"All Customer with the same firstname: {item}");
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();

        }

        private static void CustomerGetAllCustomersWithSameLastName(RestService rserv)
        {
            Console.Clear();
            var list = rserv.Get<double>("api/Stat/CustomerGetAllCustomersWithSameLastName"); foreach (var item in list)
            {
                Console.WriteLine($"All Customer with the same lastname: {item}");
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();

        }
        #endregion

        #region repairer
        private static void RepairerGetAllRepairerWithSameFirstName(RestService rserv)
        {
            Console.Clear();
            var list = rserv.Get<double>("api/Stat/RepairerGetAllRepairerWithSameFirstName"); foreach (var item in list)
            {
                Console.WriteLine($"All Repairer with the same firstname: {item}");
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void RepairerGetAllRepairerWithSameLastName(RestService rserv)
        {
            Console.Clear();
            var list = rserv.Get<double>("api/Stat/RepairerGetAllRepairerWithSameLastName"); foreach (var item in list)
            {
                Console.WriteLine($"All Repairer with the same lastname: {item}");
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }
        #endregion

        #endregion
    }
}
