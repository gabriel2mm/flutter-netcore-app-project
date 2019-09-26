using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Column("Name")]
        [StringLength(30)]
        [Index(IsUnique = true)]
        [Required]
        public String Name { get; set; }
        [Column("Type")]
        [Required]
        public CategoryType CategoryType { get; set; }
        [Column("Active")]
        public bool Active { get; set; }
    }
}
