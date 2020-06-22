using System.ComponentModel.DataAnnotations;

namespace GestaoPomarWeb.Models
{
    public class ArvoresViewModel
    {
        [Key]
        public int IdArvore
        {
            get; set;
        }

        public int IdEspecie
        {
            get; set;
        }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Código")]
        public string CodigoArvore
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

        public int Idade
        {
            get; set;
        }

        public virtual EspeciesViewModel Especie
        {
            get; set;
        }
    }
}
