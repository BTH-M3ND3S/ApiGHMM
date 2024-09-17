using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface ISetorRepositorio
    {
        Task<List<SetorModel>> GetAll();

        Task<SetorModel> GetById(int id);

        Task<SetorModel> InsertSetor(SetorModel setor);

        Task<SetorModel> UpdateSetor(SetorModel setor, int id);

        Task<bool> DeleteSetor(int id);
    }
}
