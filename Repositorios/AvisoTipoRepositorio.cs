using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class AvisoTipoRepositorio : IAvisoTipoRepositorio
    {
        private readonly Contexto _dbContext;

        public AvisoTipoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AvisoTipoModel>> GetAll()
        {
            return await _dbContext.AvisoTipo.ToListAsync();
        }

        public async Task<AvisoTipoModel> GetById(int id)
        {
            return await _dbContext.AvisoTipo.FirstOrDefaultAsync(x => x.AvisoTipoId == id);
        }

        public async Task<AvisoTipoModel> InsertAvisoTipo(AvisoTipoModel avisoTipo)
        {
            await _dbContext.AvisoTipo.AddAsync(avisoTipo);
            await _dbContext.SaveChangesAsync();
            return avisoTipo;
        }

        public async Task<AvisoTipoModel> UpdateAvisoTipo(AvisoTipoModel avisoTipo, int id)
        {
            AvisoTipoModel avisoTipoExistente = await GetById(id);
            if (avisoTipoExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                avisoTipoExistente.AvisoTipoNome = avisoTipo.AvisoTipoNome;
                await _dbContext.SaveChangesAsync();
            }
            return avisoTipoExistente;
        }

        public async Task<bool> DeleteAvisoTipo(int id)
        {
            AvisoTipoModel avisoTipo = await GetById(id);
            if (avisoTipo == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.AvisoTipo.Remove(avisoTipo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
