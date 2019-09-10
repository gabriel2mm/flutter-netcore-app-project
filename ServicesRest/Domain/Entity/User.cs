using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
