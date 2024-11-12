namespace ApiGHMM.Models
{
    public class AvisoModel
    {
        public int AvisoId { get; set; }

        public string AvisoConteudo { get; set; } = string.Empty;

        public Boolean AvisoVisto { get; set; }

        public int UsuarioId { get; set; }
        
        public int AvisoTipoId { get; set; }

        public static implicit operator List<object>(AvisoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
