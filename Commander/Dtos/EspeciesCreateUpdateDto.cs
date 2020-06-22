using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class EspeciesCreateUpdateDto
    {
        [Required]
        [MaxLength(10)]
        public string CodigoEspecie { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }
    }
}