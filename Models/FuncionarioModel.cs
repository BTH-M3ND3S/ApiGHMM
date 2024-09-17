namespace ApiGHMM.Models
{
    public class FuncionarioModel
    {
        public int FuncionarioId { get; set; }

        public string FotoUrl{ get; set; } = string.Empty;

        public string FuncionarioNome { get; set; } = string.Empty;

        public string FuncionarioCpf{ get; set; } = string.Empty;

        public string FuncionarioEmail { get; set; } = string.Empty;

        public string FuncionarioTelefone { get; set; } = string.Empty;

        public DateTime FuncionarioDataNascimento { get; set; }

        public string FuncionarioEscolaridade { get; set; } = string.Empty;

        public string FuncionarioSenha { get; set; } = string.Empty;

        public int CargoId { get; set; } 

        public int SetorId { get; set; }




        public static implicit operator List<object>(FuncionarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
