using System;

namespace Commander.Dtos
{
    public class ColheitaReadDto
    {
        public int IdColheita { get; set; }
        
        public int IdArvore { get; set; }

        public string Info { get; set; }

        public DateTime DataColheita { get; set; }

        public decimal PesoBruto { get; set; }
    }
}
