using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface ITipoManutencaoRepositorio
    {
        Task<List<TipoManutencaoModel>> GetAll();

        Task<TipoManutencaoModel> GetById(int id);

        Task<TipoManutencaoModel> InsertTipoManutencao(TipoManutencaoModel tipomanutencao);

        Task<TipoManutencaoModel> UpdateTipoManutencao(TipoManutencaoModel tipomanutencao, int id);

        Task<bool> DeleteTipoManutencao(int id);
    }
}
