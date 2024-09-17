using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IManutencaoRepositorio
    {
        Task<List<ManutencaoModel>> GetAll();

        Task<ManutencaoModel> GetById(int id);

        Task<ManutencaoModel> InsertManutencao(ManutencaoModel manutencao);

        Task<ManutencaoModel> UpdateManutencao(ManutencaoModel manutencao, int id);

        Task<bool> DeleteManutencao(int id);
    }
}
