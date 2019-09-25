using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Model")]
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Column("Name")]
        [Required]
        [StringLength(30)]
        [Index(IsUnique =true)]
        public string Name { get; set; }
        [Column("Categoty")]
        [Required]
        public Category Category { get; set; }
        [Column("Brand")]
        [Required]
        public Brand Brand { get; set;  }
        [Column("Active")]
        public bool Active { get; set; }
    }
}
