namespace Commander.Dtos
{
    public class GrupoArvoresReadDto
    {
        public int IdGrupoArvore { get; set; }
        
        public int IdArvore { get; set; }

        public string CodigoGrupoArvore { get; set; }

        public string Nome { get; set; }
        
        public string Descricao { get; set; }
    }
}