using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HX0KAT_HFT_2021222.Models
{
    public class Repairer : Entity 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Phone> Phones { get; set; }

        public Repairer()
        {
            this.Phones = new HashSet<Phone>();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Firstname: {FirstName}, Lastname: {LastName}";
        }
    }
}
