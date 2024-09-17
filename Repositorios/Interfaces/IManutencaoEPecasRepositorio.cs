using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IManutencaoEPecasRepositorio
    {
        Task<List<ManutencaoEPecasModel>> GetAll();

        Task<ManutencaoEPecasModel> GetById(int id);

        Task<ManutencaoEPecasModel> InsertManutencaoEPecas(ManutencaoEPecasModel manutencaoepecas);

        Task<ManutencaoEPecasModel> UpdateManutencaoEPecas(ManutencaoEPecasModel manutencaoepecas, int id);

        Task<bool> DeleteManutencaoEPecas(int id);
    }
}
