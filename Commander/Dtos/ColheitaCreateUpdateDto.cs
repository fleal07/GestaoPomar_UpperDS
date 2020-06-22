using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class ColheitaCreateUpdateDto
    {
        [Required]
        public int IdArvore { get; set; }

        [Required]
        [MaxLength(250)]
        public string Info { get; set; }

        [Required]
        public DateTime DataColheita { get; set; }

        [Required]
        public decimal PesoBruto { get; set; }
    }
}
