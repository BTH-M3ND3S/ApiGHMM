using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface ICategoriaPecaRepositorio
    {
        Task<List<CategoriaPecaModel>> GetAll();

        Task<CategoriaPecaModel> GetById(int id);

        Task<CategoriaPecaModel> InsertCategoriaPeca(CategoriaPecaModel categoriapeca);

        Task<CategoriaPecaModel> UpdateCategoriaPeca(CategoriaPecaModel categoriapeca, int id);

        Task<bool> DeleteCategoriaPeca(int id);
    }
}
