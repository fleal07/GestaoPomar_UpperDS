using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Colheita
    {
        [Key]
        public int IdColheita { get; set; }

        public int IdArvore { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Info { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataColheita { get; set; }

        public decimal PesoBruto { get; set; }
    }
}
