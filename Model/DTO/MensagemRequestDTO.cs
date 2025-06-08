using System.ComponentModel.DataAnnotations;

namespace eliza2_api.Model.DTO
{
    public class MensagemRequestDTO
    {

        public int Id { get; set; }

        [Required]
        public string Texto { get; set; }
    }
}
