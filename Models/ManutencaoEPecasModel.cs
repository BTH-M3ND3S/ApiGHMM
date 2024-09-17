namespace ApiGHMM.Models
{
    public class ManutencaoEPecasModel
    {
        public int ManutencaoEPecasId { get; set; }

        public int ManutencaoId { get; set; }

        public int PecaId { get; set; }

        public static implicit operator List<object>(ManutencaoEPecasModel v)
        {
            throw new NotImplementedException();
        }
    }
}
