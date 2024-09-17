using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface ITipoMaquinaRepositorio
    {
        Task<List<TipoMaquinaModel>> GetAll();

        Task<TipoMaquinaModel> GetById(int id);

        Task<TipoMaquinaModel> InsertTipoMaquina(TipoMaquinaModel tipomaquina);

        Task<TipoMaquinaModel> UpdateTipoMaquina(TipoMaquinaModel tipomaquina, int id);

        Task<bool> DeleteTipoMaquina(int id);
    }
}
