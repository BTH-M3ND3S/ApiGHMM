using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IRelatorioRepositorio
    {
        Task<List<RelatorioModel>> GetAll();

        Task<RelatorioModel> GetById(int id);

        Task<RelatorioModel> InsertRelatorio(RelatorioModel relatorio);

        Task<RelatorioModel> UpdateRelatorio(RelatorioModel relatorio, int id);

        Task<bool> DeleteRelatorio(int id);

    }
}
