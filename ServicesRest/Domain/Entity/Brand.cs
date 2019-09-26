using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Column("Name")]
        [Index(IsUnique =true)]
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        [Column("Ative")]
        public bool Active { get; set; }

    }
}
