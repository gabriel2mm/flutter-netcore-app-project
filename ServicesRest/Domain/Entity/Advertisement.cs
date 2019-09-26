using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Advertisement")]
    public class Advertisement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Column("Title")]
        [StringLength(40)]
        [Required]
        public string Title { get; set; }

        [Column("Description")]
        [StringLength(60)]
        [Required]
        public string Description { get; set; }

        [Column("Price")]
        [Required]
        public double Price { get; set; }

        [Column("Organization")]
        [Required]
        public Organization Organization { get; set; }

        [Column("Part")]
        [Required]
        public Part Part { get; set; }

        [Column("State")]
        [StringLength(40)]
        [Required]
        public string State { get; set; }

        [Column("City")]
        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [Column("Active")]
        public bool Active { get; set; }
        
    }
}
