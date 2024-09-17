using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface ICargoRepositorio
    {
        Task<List<CargoModel>> GetAll();

        Task<CargoModel> GetById(int id);

        Task<CargoModel> InsertCargo(CargoModel cargo);

        Task<CargoModel> UpdateCargo(CargoModel cargo, int id);

        Task<bool> DeleteCargo(int id);
    }
}
