namespace ApiGHMM.Models
{
    public class PecaModel
    {
        public int PecaId { get; set; }

        public string PecaNome { get; set; } = string.Empty;

        public int QuantidadeEstoque { get; set; }

        public int FornecedorId { get; set; }

        public int CategoriaPecaId { get; set; }

        public static implicit operator List<object>(PecaModel v)
        {
            throw new NotImplementedException();
        }
    }
}
