using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class TecnicoUsuarioRepositorio : ITecnicoUsuarioRepositorio
    {
        private readonly Contexto _dbContext;

        public TecnicoUsuarioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TecnicoUsuarioModel>> GetAll()
        {
            return await _dbContext.TecnicoUsuario.ToListAsync();
        }

        public async Task<TecnicoUsuarioModel> GetById(int id)
        {
            return await _dbContext.TecnicoUsuario.FirstOrDefaultAsync(x => x.TecnicoUsuarioId == id);
        }

        public async Task<TecnicoUsuarioModel> InsertTecnicoUsuario(TecnicoUsuarioModel tecnicousuario)
        {
            await _dbContext.TecnicoUsuario.AddAsync(tecnicousuario);
            await _dbContext.SaveChangesAsync();
            return tecnicousuario;
        }

        public async Task<TecnicoUsuarioModel> UpdateTecnicoUsuario(TecnicoUsuarioModel tecnicousuario, int id)
        {
            TecnicoUsuarioModel tecnicousuarioExistente = await GetById(id);
            if (tecnicousuarioExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tecnicousuarioExistente.Tecnicos= tecnicousuario.Tecnicos;
                tecnicousuarioExistente.Usuario = tecnicousuario.Usuario;
                _dbContext.TecnicoUsuario.Update(tecnicousuarioExistente);
                await _dbContext.SaveChangesAsync();
            }
            return tecnicousuarioExistente;
        }

        public async Task<bool> DeleteTecnicoUsuario(int id)
        {
            TecnicoUsuarioModel tecnicousuario = await GetById(id);
            if (tecnicousuario == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TecnicoUsuario.Remove(tecnicousuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
