using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetAll();

        Task<UsuarioModel> GetById(int id);

        Task<UsuarioModel> InsertUsuario(UsuarioModel usuario);

        Task<UsuarioModel> UpdateUsuario(UsuarioModel usuario, int id);

        Task<bool> DeleteUsuario(int id);

        Task<bool> Login(string cpf,  string password);
    }
}
