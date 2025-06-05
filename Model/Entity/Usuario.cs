using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eliza2_api.Model.Entity
{
    [Table("USUARIOS_CSHARP")]

    public class Usuario
    {

        [Key]
        public int Id { get; set; }
        [Required, MaxLength(120)]
        public string Nome { get; set; }

        [Required, MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6), MaxLength(110)]
        public string SenhaHash { get; set; }

        public ICollection<Mensagem> Mensagens { get; set; }


    }
}
