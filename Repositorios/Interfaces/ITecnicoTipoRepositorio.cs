using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface ITecnicoTipoRepositorio
    {
        Task<List<TecnicoTipoModel>> GetAll();

        Task<TecnicoTipoModel> GetById(int id);

        Task<TecnicoTipoModel> InsertTecnicoTipo(TecnicoTipoModel tecnicotipo);

        Task<TecnicoTipoModel> UpdateTecnicoTipo(TecnicoTipoModel tecnicotipo, int id);

        Task<bool> DeleteTecnicoTipo(int id);
    }
}
