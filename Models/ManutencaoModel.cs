namespace ApiGHMM.Models
{
    public class ManutencaoModel
    {
        public int ManutencaoId { get; set; }

        public int TipoManutencaoId { get; set; } 

        public DateTime ManutencaoData { get; set; }

        public string ManutencaoDescricao { get; set; } = string.Empty;

        public decimal ManutencaoCusto { get; set; }

        public int TecnicosId { get; set; }


        public static implicit operator List<object>(ManutencaoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
