using System.ComponentModel.DataAnnotations;

namespace eliza2_api.Model.DTO
{
    public class MensagemRespDto
    {
        public int Id { get; set; }

        [Required]
        public string RespostaBot { get; set; }
    }
}
