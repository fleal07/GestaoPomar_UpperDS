using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class GrupoArvores
    {
        [Key]
        public int IdGrupoArvore { get; set; }

        public int IdArvore { get; set; }

        [Required]
        [MaxLength(10)]
        public string CodigoGrupoArvore { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }
    }
}