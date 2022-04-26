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
    public class Customer : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id", TypeName = "int")]
        public override int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }



        //[ForeignKey(nameof(Phone))]
        //public int PhoneId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Phone> Phone { get; set; }

    }
}
