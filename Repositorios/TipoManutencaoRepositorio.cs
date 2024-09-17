using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class TipoManutencaoRepositorio : ITipoManutencaoRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoManutencaoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoManutencaoModel>> GetAll()
        {
            return await _dbContext.TipoManutencao.ToListAsync();
        }

        public async Task<TipoManutencaoModel> GetById(int id)
        {
            return await _dbContext.TipoManutencao.FirstOrDefaultAsync(x => x.TipoManutencaoId == id);
        }

        public async Task<TipoManutencaoModel> InsertTipoManutencao(TipoManutencaoModel tipoManutencao)
        {
            await _dbContext.TipoManutencao.AddAsync(tipoManutencao);
            await _dbContext.SaveChangesAsync();
            return tipoManutencao;
        }

        public async Task<TipoManutencaoModel> UpdateTipoManutencao(TipoManutencaoModel tipoManutencao, int id)
        {
            TipoManutencaoModel tipoManutencaoExistente = await GetById(id);
            if (tipoManutencaoExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoManutencaoExistente.TipoManutencaoNome = tipoManutencao.TipoManutencaoNome;
                await _dbContext.SaveChangesAsync();
            }
            return tipoManutencaoExistente;
        }

        public async Task<bool> DeleteTipoManutencao(int id)
        {
            TipoManutencaoModel tipoManutencao = await GetById(id);
            if (tipoManutencao == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoManutencao.Remove(tipoManutencao);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
