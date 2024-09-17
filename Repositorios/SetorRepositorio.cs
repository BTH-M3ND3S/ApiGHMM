using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class SetorRepositorio : ISetorRepositorio
    {
        private readonly Contexto _dbContext;

        public SetorRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SetorModel>> GetAll()
        {
            return await _dbContext.Setor.ToListAsync();
        }

        public async Task<SetorModel> GetById(int id)
        {
            return await _dbContext.Setor.FirstOrDefaultAsync(x => x.SetorId == id);
        }

        public async Task<SetorModel> InsertSetor(SetorModel setor)
        {
            await _dbContext.Setor.AddAsync(setor);
            await _dbContext.SaveChangesAsync();
            return setor;
        }

        public async Task<SetorModel> UpdateSetor(SetorModel setor, int id)
        {
            SetorModel setorExistente = await GetById(id);
            if (setorExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                setorExistente.SetorNome = setor.SetorNome;
                await _dbContext.SaveChangesAsync();
            }
            return setorExistente;
        }

        public async Task<bool> DeleteSetor(int id)
        {
            SetorModel setor = await GetById(id);
            if (setor == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Setor.Remove(setor);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
