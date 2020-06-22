using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoPomarWeb.Models
{
    public class ColheitaViewModel
    {
        [Key]
        public int IdColheita
        {
            get; set;
        }

        public int IdArvore
        {
            get; set;
        }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Informações Colheita")]
        public string Info
        {
            get; set;
        }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Colheita")]
        public DateTime DataColheita
        {
            get; set;
        }

        [Display(Name = "Peso Bruto")]
        public decimal PesoBruto
        {
            get; set;
        }
    }
}
