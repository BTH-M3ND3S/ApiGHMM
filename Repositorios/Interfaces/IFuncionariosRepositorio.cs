using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IFuncionariosRepositorio
    {
        Task<List<FuncionarioModel>> GetAll();

        Task<FuncionarioModel> GetById(int id);

        Task<FuncionarioModel> InsertFuncionario(FuncionarioModel funcionario);

        Task<FuncionarioModel> UpdateFuncionario(FuncionarioModel funcionario, int id);

        Task<bool> DeleteFuncionario(int id);
    }
}
