using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HX0KAT_HFT_2021222.Models
{
    public class Phone : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public Brand Brand { get; set; } //this should be an Enum/Internal class
        public string Model { get; set; } //this should be an Enum/Internal class

        public int? Price { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Customer Customer { get; set; }


        [ForeignKey(nameof(Repairer))]
        public int RepairerId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Repairer Repairer { get; set; }

    }
}
