using System;

namespace HX0KAT_HFT_2021222.Models
{
    public class Phone : Entity
    {
        public override int Id { get; set; }

        public string Brand { get; set; } //this should be an Enum
    }
}
