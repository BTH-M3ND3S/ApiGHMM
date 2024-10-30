using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IAvisoTipoRepositorio
    {
        Task<List<AvisoTipoModel>> GetAll();

        Task<AvisoTipoModel> GetById(int id);

        Task<AvisoTipoModel> InsertAvisoTipo(AvisoTipoModel avisotipo);

        Task<AvisoTipoModel> UpdateAvisoTipo(AvisoTipoModel avisotipo, int id);

        Task<bool> DeleteAvisoTipo(int id);
    }
}
