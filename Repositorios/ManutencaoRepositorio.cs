using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class ManutencaoRepositorio : IManutencaoRepositorio
    {
        private readonly Contexto _dbContext;

        public ManutencaoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ManutencaoModel>> GetAll()
        {
            return await _dbContext.Manutencao.ToListAsync();
        }

        public async Task<ManutencaoModel> GetById(int id)
        {
            return await _dbContext.Manutencao.FirstOrDefaultAsync(x => x.ManutencaoId == id);
        }

        public async Task<ManutencaoModel> InsertManutencao(ManutencaoModel manutencao)
        {
            await _dbContext.Manutencao.AddAsync(manutencao);
            await _dbContext.SaveChangesAsync();
            return manutencao;
        }

        public async Task<ManutencaoModel> UpdateManutencao(ManutencaoModel manutencao, int id)
        {
            ManutencaoModel manutencaoExistente = await GetById(id);
            if (manutencaoExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                manutencaoExistente.TipoManutencaoId = manutencao.TipoManutencaoId;
                manutencaoExistente.ManutencaoData = manutencao.ManutencaoData;
                manutencaoExistente.ManutencaoDescricao = manutencao.ManutencaoDescricao;
                manutencaoExistente.ManutencaoCusto = manutencao.ManutencaoCusto;
                await _dbContext.SaveChangesAsync();
            }
            return manutencaoExistente;
        }

        public async Task<bool> DeleteManutencao(int id)
        {
            ManutencaoModel manutencao = await GetById(id);
            if (manutencao == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Manutencao.Remove(manutencao);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
