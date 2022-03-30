using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.Models
{
    public interface IEntity <TId>
    {
        TId Id { get; set; }
    }
}
