using System.ComponentModel.DataAnnotations;

namespace eliza2_api.Model.DTO
{
    public class UsuarioRegisterDTO
    {
        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Senha { get; set; }
    }
}
