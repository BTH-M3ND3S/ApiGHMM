using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class RelatorioRepositorio : IRelatorioRepositorio
    {
        private readonly Contexto _dbContext;

        public RelatorioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RelatorioModel>> GetAll()
        {
            return await _dbContext.Relatorio.ToListAsync();
        }

        public async Task<RelatorioModel> GetById(int id)
        {
            return await _dbContext.Relatorio.FirstOrDefaultAsync(x => x.RelatorioId == id);
        }

        public async Task<RelatorioModel> InsertRelatorio(RelatorioModel relatorio)
        {
            await _dbContext.Relatorio.AddAsync(relatorio);
            await _dbContext.SaveChangesAsync();
            return relatorio;
        }

        public async Task<RelatorioModel> UpdateRelatorio(RelatorioModel relatorio, int id)
        {
            RelatorioModel relatorioExistente = await GetById(id);
            if (relatorioExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                relatorioExistente.RelatorioConteudo = relatorio.RelatorioConteudo;
                await _dbContext.SaveChangesAsync();
            }
            return relatorioExistente;
        }

        public async Task<bool> DeleteRelatorio(int id)
        {
            RelatorioModel relatorio = await GetById(id);
            if (relatorio == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Relatorio.Remove(relatorio);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
