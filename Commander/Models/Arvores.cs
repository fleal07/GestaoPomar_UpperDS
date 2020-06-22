using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Arvores
    {
        [Key]
        public int IdArvore { get; set; }

        public int IdEspecie { get; set; }

        [Required]
        [MaxLength(10)]
        public string CodigoArvore { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }

        public int Idade { get; set; }
    }
}
