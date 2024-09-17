using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IFabricanteRepositorio
    {

        Task<List<FabricanteModel>> GetAll();

        Task<FabricanteModel> GetById(int id);

        Task<FabricanteModel> InsertFabricante(FabricanteModel fabricante);

        Task<FabricanteModel> UpdateFabricante(FabricanteModel fabricante, int id);

        Task<bool> DeleteFabricante(int id);

    }
}
