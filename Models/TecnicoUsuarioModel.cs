namespace ApiGHMM.Models
{
    public class TecnicoUsuarioModel
    {
        public int TecnicoUsuarioId { get; set; }

        public int Tecnicos { get; set; }

        public int Usuario { get; set; }

        public static implicit operator List<object>(TecnicoUsuarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
