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

                .Add(">> EXIT", ConsoleMenu.Close);


            menu.Show();
        }

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
            Console.WriteLine("Choose Brand:");
            phone.Brand = Console.ReadLine();
            //foreach (var item in Enum.GetValues(typeof(Brand)))
            //{
            //    Console.WriteLine(item);
            //}
            //phone.Brand = Enum.Parse<Brand>(Console.ReadLine());

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
        #endregion

    }
}
