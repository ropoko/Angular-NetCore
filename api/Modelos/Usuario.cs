using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Modelos
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("IDUsuario")]
        public int IDUsuario { get; set; }

        [Required]
        [MaxLength(60)]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(60)]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(60)]
        [Column("Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(60)]
        [Column("Role")]
        public string Role { get; set; }
    }
}