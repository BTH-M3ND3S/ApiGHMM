using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class TecnicoTipoRepositorio : ITecnicoTipoRepositorio
    {
        private readonly Contexto _dbContext;

        public TecnicoTipoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TecnicoTipoModel>> GetAll()
        {
            return await _dbContext.TecnicoTipo.ToListAsync();
        }

        public async Task<TecnicoTipoModel> GetById(int id)
        {
            return await _dbContext.TecnicoTipo.FirstOrDefaultAsync(x => x.TecnicoTipoId == id);
        }

        public async Task<TecnicoTipoModel> InsertTecnicoTipo(TecnicoTipoModel tecnicoTipo)
        {
            await _dbContext.TecnicoTipo.AddAsync(tecnicoTipo);
            await _dbContext.SaveChangesAsync();
            return tecnicoTipo;
        }

        public async Task<TecnicoTipoModel> UpdateTecnicoTipo(TecnicoTipoModel tecnicoTipo, int id)
        {
            TecnicoTipoModel tecnicoTipoExistente = await GetById(id);
            if (tecnicoTipoExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tecnicoTipoExistente.TecnicoDescricao = tecnicoTipo.TecnicoDescricao;

                await _dbContext.SaveChangesAsync();
            }
            return tecnicoTipoExistente;
        }

        public async Task<bool> DeleteTecnicoTipo(int id)
        {
            TecnicoTipoModel tecnicoTipo = await GetById(id);
            if (tecnicoTipo == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TecnicoTipo.Remove(tecnicoTipo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
