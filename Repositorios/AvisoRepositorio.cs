using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class AvisoRepositorio : IAvisoRepositorio
    {
        private readonly Contexto _dbContext;

        public AvisoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AvisoModel>> GetAll()
        {
            return await _dbContext.Aviso.ToListAsync();
        }

        public async Task<AvisoModel> GetById(int id)
        {
            return await _dbContext.Aviso.FirstOrDefaultAsync(x => x.AvisoId == id);
        }

        public async Task<AvisoModel> InsertAviso(AvisoModel aviso)
        {
            await _dbContext.Aviso.AddAsync(aviso);
            await _dbContext.SaveChangesAsync();
            return aviso;
        }

        public async Task<AvisoModel> UpdateAviso(AvisoModel aviso, int id)
        {
            AvisoModel avisoExistente = await GetById(id);
            if (avisoExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                avisoExistente.AvisoConteudo = aviso.AvisoConteudo;
                avisoExistente.AvisoVisto = aviso.AvisoVisto;
                avisoExistente.Usuario = aviso.Usuario;
                avisoExistente.AvisoTipo = aviso.AvisoTipo;
                await _dbContext.SaveChangesAsync();
            }
            return avisoExistente;
        }

        public async Task<bool> DeleteAviso(int id)
        {
            AvisoModel aviso = await GetById(id);
            if (aviso == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Aviso.Remove(aviso);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
