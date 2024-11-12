namespace ApiGHMM.Models
{
    public class AvisoCompleto
    {
        public int AvisoId { get; set; }

        public string AvisoConteudo { get; set; } = string.Empty;

        public Boolean AvisoVisto { get; set; }

        public UsuarioModel Usuario { get; set; }

        public AvisoTipoModel AvisoTipo { get; set; }

        public static implicit operator List<object>(AvisoCompleto v)
        {
            throw new NotImplementedException();
        }
    }
}
