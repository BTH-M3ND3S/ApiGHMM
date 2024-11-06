namespace ApiGHMM.Models
{
    public class MaquinaModel
    {
        public int MaquinaId { get; set; }

        public string Nome { get; set; } = string.Empty;

        public int TipoMaquinaId { get; set; }

        public int SetorId { get; set; }

        public string Modelo { get; set; } = string.Empty;

        public string NumeroSerie { get; set; } = string.Empty;

        public int FabricanteId { get; set; }

        public DateTime DataAquisicao { get; set; }

        public string FotoUrl { get; set; } = string.Empty;
        
        public float Peso { get; set; }

        public int Voltagem { get; set; }

        public string MaquinaDetalhes { get; set; }

        public static implicit operator List<object>(MaquinaModel v)
        {
            throw new NotImplementedException();
        }
    }
}
