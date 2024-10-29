using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface ITecnicoUsuarioRepositorio
    {
        Task<List<TecnicoUsuarioModel>> GetAll();

        Task<TecnicoUsuarioModel> GetById(int id);

        Task<TecnicoUsuarioModel> InsertTecnicoUsuario(TecnicoUsuarioModel tecnico);

        Task<TecnicoUsuarioModel> UpdateTecnicoUsuario(TecnicoUsuarioModel tecnico, int id);

        Task<bool> DeleteTecnicoUsuario(int id);
    }
}
