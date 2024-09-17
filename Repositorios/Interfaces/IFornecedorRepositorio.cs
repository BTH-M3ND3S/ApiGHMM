using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IFornecedorRepositorio 
    {
        Task<List<FornecedorModel>> GetAll();

        Task<FornecedorModel> GetById(int id);

        Task<FornecedorModel> InsertFornecedor(FornecedorModel fornecedor);

        Task<FornecedorModel> UpdateFornecedor(FornecedorModel fornecedor, int id);

        Task<bool> DeleteFornecedor(int id);

    }
}
