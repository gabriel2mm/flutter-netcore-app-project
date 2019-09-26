using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Column("First_name")]
        [Required(ErrorMessage ="First_name é necessário")]
        [StringLength(50, ErrorMessage = "First_name só pode conter 50 caractres")]
        public string First_Name { get; set; }

        [Column("Last_name")]
        [Required(ErrorMessage = "Last_name é necessário")]
        [StringLength(50, ErrorMessage = "Last_name só pode conter 50 caractres")]
        public string Last_name { get; set; }

        [Column("Email")]
        [Required(ErrorMessage = "E-mail é necessário")]
        [StringLength(100, ErrorMessage = "E-mail só pode conter 100 caractres")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Column("Login")]
        [Required(ErrorMessage = "Login é necessário")]
        [StringLength(30, ErrorMessage = "Login só pode conter 30 caractres")]
        [Index(IsUnique = true)]
        public string Login { get; set; }

        [Column("Password")]
        [Required(ErrorMessage = "Password é necessário")]
        [StringLength(30, ErrorMessage = "Password só pode conter 30 caractres")]
        [Index(IsUnique = true)]
        public string Password { get; set; }

        [Column("Perfil")]
        [Required(ErrorMessage = "Perfil é necessário")]
        private PerfilType Perfil { get; set; }
    }
}
