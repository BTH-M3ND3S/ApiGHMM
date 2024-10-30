namespace ApiGHMM.Models
{
    public class AvisoModel
    {
        public int AvisoId { get; set; }

        public string AvisoConteudo { get; set; } = string.Empty;

        public Boolean AvisoVisto { get; set; }

        public int Usuario { get; set; }
        
        public int AvisoTipo { get; set; }

        public static implicit operator List<object>(AvisoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
