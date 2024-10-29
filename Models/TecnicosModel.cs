namespace ApiGHMM.Models
{
    public class TecnicosModel
    {
        public int TecnicosId { get; set; }

        public string TecnicoNome { get; set; } = string.Empty;

        public string TecnicoDetalhes { get; set; } = string.Empty;

        public int TecnicoTipo { get; set; }

        public static implicit operator List<object>(TecnicosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
