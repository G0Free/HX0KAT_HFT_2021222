﻿using HX0KAT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.DataAccess.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void UpdateFirstName(int id, string newFirstName);
        void UpdateLastName(int id, string newLastName);
        void UpdateEmail(int id, string newEmail);

    }
}
