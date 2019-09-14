using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public long ID { get; set; }

        [Column("Organization")]
        [Required(ErrorMessage = "Organization é necessário")]
        public Organization Organization { get; set; }
      
        [Column("ContactName")]
        [StringLength(30, ErrorMessage = "ContactName só pode conter 30 caractres")]
        [Index(IsUnique = true)]
        public string ContactName { get; set; }

        [Column("Email")]
        [StringLength(100, ErrorMessage = "Email só pode conter 100 caractres")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Column("Landline")]

        [StringLength(11, ErrorMessage = "Landline só pode conter 11 caractres")]
        [Index(IsUnique = true)]
        public string Landline { get; set; }

        [Column("CellPhone")]
        [StringLength(11, ErrorMessage = "CellPhone só pode conter 11 caractres")]
        [Index(IsUnique = true)]
        public string CellPhone { get; set; }
    }
}
