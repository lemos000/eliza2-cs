using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eliza2_api.Model.Entity
{
    [Table("MENSAGENS_CSHARP")]

    public class Mensagem
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; } // atributo da fk

        [ForeignKey("UsuarioId")]
        [Required]
        public Usuario Usuario { get; set; }

        [Required]
        public string TextoUsuario { get; set; }

        [Required]
        public string RespostaBot { get; set; }

        public DateTime DataHora { get; set; } = DateTime.UtcNow;


    }
}
