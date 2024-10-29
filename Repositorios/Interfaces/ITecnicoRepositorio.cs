using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface ITecnicoRepositorio
    {
        Task<List<TecnicosModel>> GetAll();

        Task<TecnicosModel> GetById(int id);

        Task<TecnicosModel> InsertTecnico(TecnicosModel tecnico);

        Task<TecnicosModel> UpdateTecnico(TecnicosModel tecnico, int id);

        Task<bool> DeleteTecnico(int id);
    }
}
