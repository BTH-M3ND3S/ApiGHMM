using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGHMM.Repositorios
{
    public class TipoMaquinaRepositorio : ITipoMaquinaRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoMaquinaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<TipoMaquinaModel>> GetAll()
        {
            return await _dbContext.TipoMaquina.ToListAsync();
        }

        public async Task<TipoMaquinaModel> GetById(int id)
        {
            return await _dbContext.TipoMaquina.FirstOrDefaultAsync(x => x.TipoMaquinaId == id);
        }

        public async Task<TipoMaquinaModel> InsertTipoMaquina(TipoMaquinaModel tipoMaquina)
        {
            if (tipoMaquina == null)
            {
                throw new ArgumentNullException(nameof(tipoMaquina));
            }

            await _dbContext.TipoMaquina.AddAsync(tipoMaquina);
            await _dbContext.SaveChangesAsync();
            return tipoMaquina;
        }

        public async Task<TipoMaquinaModel> UpdateTipoMaquina(TipoMaquinaModel tipoMaquina, int id)
        {
            if (tipoMaquina == null)
            {
                throw new ArgumentNullException(nameof(tipoMaquina));
            }

            var tipoMaquinaExistente = await GetById(id);
            if (tipoMaquinaExistente == null)
            {
                throw new Exception("Tipo de máquina não encontrado.");
            }

            tipoMaquinaExistente.TipoMaquinaNome = tipoMaquina.TipoMaquinaNome;
            await _dbContext.SaveChangesAsync();
            return tipoMaquinaExistente;
        }

        public async Task<bool> DeleteTipoMaquina(int id)
        {
            var tipoMaquina = await GetById(id);
            if (tipoMaquina == null)
            {
                throw new Exception("Tipo de máquina não encontrado.");
            }

            _dbContext.TipoMaquina.Remove(tipoMaquina);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
