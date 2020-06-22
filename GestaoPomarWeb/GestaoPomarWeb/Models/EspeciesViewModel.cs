using System.ComponentModel.DataAnnotations;

namespace GestaoPomarWeb.Models
{
    public class EspeciesViewModel
    {
        [Key]
        public int IdEspecie
        {
            get; set;
        }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Código")]
        public string CodigoEspecie
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
