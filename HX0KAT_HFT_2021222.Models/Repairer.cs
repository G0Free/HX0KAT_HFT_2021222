using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.Models
{
    public class Repairer : Entity 
    {
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
