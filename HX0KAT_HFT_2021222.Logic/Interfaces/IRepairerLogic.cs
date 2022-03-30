using HX0KAT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.Logic.Interfaces
{
    public interface IRepairerLogic
    {
        void Create(Repairer repairer);
        Repairer Read(int id);
        IEnumerable<Repairer> ReadAll();
        void Update(Repairer repairer);
        void Delete(int id);
    }
}
