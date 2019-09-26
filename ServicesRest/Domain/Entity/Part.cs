using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Part")]
    public class Part
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Column("Name")]
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        [Column("Model")]
        [Required]
        public Model Modelo { get; set; }
        [Column("Active")]
        public bool Active { get; set; }
    }
}
