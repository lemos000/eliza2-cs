using System.ComponentModel.DataAnnotations;

namespace eliza2_api.Model.DTO
{
    public class UsuarioLoginDTO
    {
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
