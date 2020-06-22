using System.ComponentModel.DataAnnotations;

namespace GestaoPomarWeb.Models
{
    public class GrupoArvoresViewModel
    {
        [Key]
        public int IdGrupoArvore
        {
            get; set;
        }

        public int IdArvore
        {
            get; set;
        }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Código")]
        public string CodigoGrupoArvore
        {
            get; set;
        }

        [Required]
        [MaxLength(100)]
        public string Nome
        {
            get; set;
        }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Descrição")]
        public string Descricao
        {
            get; set;
        }
    }
}
