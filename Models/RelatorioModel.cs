namespace ApiGHMM.Models
{
    public class RelatorioModel
    {
        public int RelatorioId { get; set; }

        public string RelatorioConteudo { get; set; } = string.Empty;

        public int FuncionarioId { get; set; }

        public static implicit operator List<object>(RelatorioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
