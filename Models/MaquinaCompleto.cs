namespace ApiGHMM.Models
{
    public class MaquinaCompleto
    {
        public int MaquinaId { get; set; }

        public string Nome { get; set; } = string.Empty;

        public FabricanteModel Fabricante { get; set; }

        public TipoMaquinaModel TipoMaquina { get; set; }

        public SetorModel Setor { get; set; }

        public string Modelo { get; set; } = string.Empty;

        public string NumeroSerie { get; set; } = string.Empty;


        public DateTime DataAquisicao { get; set; }

        public string FotoUrl { get; set; } = string.Empty;

        public float Peso { get; set; }

        public int Voltagem { get; set; }

        public string MaquinaDetalhes { get; set; } = string.Empty;

        public static implicit operator List<object>(MaquinaCompleto v)
        {
            throw new NotImplementedException();
        }
    }
}
