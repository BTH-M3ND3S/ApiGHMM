namespace ApiGHMM.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }

        public string FotoUrl{ get; set; } = string.Empty;

        public string UsuarioNome { get; set; } = string.Empty;

        public string UsuarioCpf { get; set; } = string.Empty;

        public string UsuarioEmail { get; set; } = string.Empty;

        public string UsuarioTelefone { get; set; } = string.Empty;

        public DateTime UsuarioDataNascimento { get; set; }

        public string UsuarioEscolaridade { get; set; } = string.Empty;

        public string UsuarioSenha { get; set; } = string.Empty;

        public int CargoId { get; set; } 

        public int SetorId { get; set; }




        public static implicit operator List<object>(UsuarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
