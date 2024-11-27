using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class CategoriaPecaRepositorio : ICategoriaPecaRepositorio
    {
        private readonly Contexto _dbContext;

        public CategoriaPecaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoriaPecaModel>> GetAll()
        {
            return await _dbContext.CategoriaPeca.ToListAsync();
        }

        public async Task<CategoriaPecaModel> GetById(int id)
        {
            return await _dbContext.CategoriaPeca.FirstOrDefaultAsync(x => x.CategoriaPecaId == id);
        }

        public async Task<CategoriaPecaModel> InsertCategoriaPeca(CategoriaPecaModel categoriaPeca)
        {
            await _dbContext.CategoriaPeca.AddAsync(categoriaPeca);
            await _dbContext.SaveChangesAsync();
            return categoriaPeca;
        }

        public async Task<CategoriaPecaModel> UpdateCategoriaPeca(CategoriaPecaModel categoriaPeca, int id)
        {
            CategoriaPecaModel categoriaPecaExistente = await GetById(id);
            if (categoriaPecaExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                categoriaPecaExistente.CategoriaPecaNome = categoriaPeca.CategoriaPecaNome;
                categoriaPecaExistente.FotoUrl = categoriaPeca.FotoUrl;
                await _dbContext.SaveChangesAsync();
            }
            return categoriaPecaExistente;
        }

        public async Task<bool> DeleteCategoriaPeca(int id)
        {
            CategoriaPecaModel categoriaPeca = await GetById(id);
            if (categoriaPeca == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.CategoriaPeca.Remove(categoriaPeca);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
