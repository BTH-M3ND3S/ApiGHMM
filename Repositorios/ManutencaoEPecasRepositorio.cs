using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class ManutencaoEPecasRepositorio : IManutencaoEPecasRepositorio
    {
        private readonly Contexto _dbContext;

        public ManutencaoEPecasRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ManutencaoEPecasModel>> GetAll()
        {
            return await _dbContext.ManutencaoEPecas.ToListAsync();
        }

        public async Task<ManutencaoEPecasModel> GetById(int id)
        {
            return await _dbContext.ManutencaoEPecas.FirstOrDefaultAsync(x => x.ManutencaoEPecasId == id);
        }

        public async Task<ManutencaoEPecasModel> InsertManutencaoEPecas(ManutencaoEPecasModel manutencaoEPecas)
        {
            await _dbContext.ManutencaoEPecas.AddAsync(manutencaoEPecas);
            await _dbContext.SaveChangesAsync();
            return manutencaoEPecas;
        }

        public async Task<ManutencaoEPecasModel> UpdateManutencaoEPecas(ManutencaoEPecasModel manutencaoEPecas, int id)
        {
            ManutencaoEPecasModel manutencaoEPecasExistente = await GetById(id);
            if (manutencaoEPecasExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                manutencaoEPecasExistente.ManutencaoId = manutencaoEPecas.ManutencaoId;
                manutencaoEPecasExistente.PecaId = manutencaoEPecas.PecaId;
                await _dbContext.SaveChangesAsync();
            }
            return manutencaoEPecasExistente;
        }

        public async Task<bool> DeleteManutencaoEPecas(int id)
        {
            ManutencaoEPecasModel manutencaoEPecas = await GetById(id);
            if (manutencaoEPecas == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.ManutencaoEPecas.Remove(manutencaoEPecas);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
