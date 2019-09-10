using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Users")]
    public class User
    {
        [Key]
        public long ID { get; set; }
        [Column("Login")]
        public string Login { get; set; }
        [Column("Password")]
        public string Password { get; set; }

    }
}
