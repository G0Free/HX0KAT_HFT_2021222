using HX0KAT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.Logic.Interfaces
{
    public interface IStatLogic
    {
        public KeyValuePair<Customer, double> CustomerWithHighestPriceSummed();
    }
}
