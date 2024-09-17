using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class FabricanteRepositorio : IFabricanteRepositorio
    {
        private readonly Contexto _dbContext;

        public FabricanteRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FabricanteModel>> GetAll()
        {
            return await _dbContext.Fabricante.ToListAsync();
        }

        public async Task<FabricanteModel> GetById(int id)
        {
            return await _dbContext.Fabricante.FirstOrDefaultAsync(x => x.FabricanteId == id);
        }

        public async Task<FabricanteModel> InsertFabricante(FabricanteModel fabricante)
        {
            await _dbContext.Fabricante.AddAsync(fabricante);
            await _dbContext.SaveChangesAsync();
            return fabricante;
        }

        public async Task<FabricanteModel> UpdateFabricante(FabricanteModel fabricante, int id)
        {
            FabricanteModel fabricanteExistente = await GetById(id);
            if (fabricanteExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                fabricanteExistente.FabricanteNome = fabricante.FabricanteNome;
                await _dbContext.SaveChangesAsync();
            }
            return fabricanteExistente;
        }

        public async Task<bool> DeleteFabricante(int id)
        {
            FabricanteModel fabricante = await GetById(id);
            if (fabricante == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Fabricante.Remove(fabricante);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
