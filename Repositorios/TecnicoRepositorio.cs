using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class TecnicoRepositorio : ITecnicoRepositorio
    {
        private readonly Contexto _dbContext;

        public TecnicoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TecnicosModel>> GetAll()
        {
            return await _dbContext.Tecnicos.ToListAsync();
        }

        public async Task<TecnicosModel> GetById(int id)
        {
            return await _dbContext.Tecnicos.FirstOrDefaultAsync(x => x.TecnicosId == id);
        }

        public async Task<TecnicosModel> InsertTecnico(TecnicosModel tecnico)
        {
            await _dbContext.Tecnicos.AddAsync(tecnico);
            await _dbContext.SaveChangesAsync();
            return tecnico;
        }

        public async Task<TecnicosModel> UpdateTecnico(TecnicosModel tecnico, int id)
        {
            TecnicosModel tecnicoExistente = await GetById(id);
            if (tecnicoExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tecnicoExistente.TecnicoNome= tecnico.TecnicoNome;
                tecnicoExistente.TecnicoDetalhes = tecnico.TecnicoDetalhes;
                tecnicoExistente.TecnicoTipo = tecnico.TecnicoTipo;
                _dbContext.Tecnicos.Update(tecnicoExistente);
                await _dbContext.SaveChangesAsync();
            }
            return tecnicoExistente;
        }

        public async Task<bool> DeleteTecnico(int id)
        {
            TecnicosModel tecnico = await GetById(id);
            if (tecnico == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Tecnicos.Remove(tecnico);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
