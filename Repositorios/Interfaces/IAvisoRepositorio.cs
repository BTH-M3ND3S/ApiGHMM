using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IAvisoRepositorio
    {
        Task<List<AvisoModel>> GetAll();

        Task<AvisoModel> GetById(int id);

        Task<AvisoModel> InsertAviso(AvisoModel aviso);

        Task<AvisoModel> UpdateAviso(AvisoModel aviso, int id);

        Task<bool> DeleteAviso(int id);
    }
}
