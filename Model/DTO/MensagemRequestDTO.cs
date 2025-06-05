using System.ComponentModel.DataAnnotations;

namespace eliza2_api.Model.DTO
{
    public class MensagemRequestDTO
    {
        [Required]
        public string Texto { get; set; }
    }
}
