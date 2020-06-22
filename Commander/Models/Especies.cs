using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Especies
    {
        [Key]
        public int IdEspecie { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string CodigoEspecie { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }
    }
}