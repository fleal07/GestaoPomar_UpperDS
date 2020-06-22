using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class ArvoresCreateUpdateDto
    {
        [Required]
        public int IdEspecie { get; set; }

        [Required]
        [MaxLength(10)]
        public string CodigoArvore { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [Required]
        public int Idade { get; set; }
    }
}