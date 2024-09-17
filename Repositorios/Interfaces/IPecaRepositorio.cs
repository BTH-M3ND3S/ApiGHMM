using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IPecaRepositorio
    {
        Task<List<PecaModel>> GetAll();

        Task<PecaModel> GetById(int id);

        Task<PecaModel> InsertPeca(PecaModel peca);

        Task<PecaModel> UpdatePeca(PecaModel peca, int id);

        Task<bool> DeletePeca(int id);
    }
}
