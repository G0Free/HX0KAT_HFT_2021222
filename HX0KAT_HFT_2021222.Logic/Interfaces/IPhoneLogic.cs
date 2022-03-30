using HX0KAT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.Logic.Interfaces
{
    public interface IPhoneLogic
    {
        void Create(Phone phone);
        Phone Read(int id);
        IEnumerable<Phone> ReadAll();
        void Update(Phone phone);
        void Delete(Phone phone);

    }
}
