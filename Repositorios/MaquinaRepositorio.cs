using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class MaquinaRepositorio : IMaquinaRepositorio
    {
        private readonly Contexto _dbContext;

        public MaquinaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MaquinaModel>> GetAll()
        {
            return await _dbContext.Maquina.ToListAsync();
        }

        public async Task<MaquinaModel> GetById(int id)
        {
            return await _dbContext.Maquina.FirstOrDefaultAsync(x => x.MaquinaId == id);
        }

        public async Task<MaquinaModel> InsertMaquina(MaquinaModel maquina)
        {
            await _dbContext.Maquina.AddAsync(maquina);
            await _dbContext.SaveChangesAsync();
            return maquina;
        }

        public async Task<MaquinaModel> UpdateMaquina(MaquinaModel maquina, int id)
        {
            MaquinaModel maquinaExistente = await GetById(id);
            if (maquinaExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                maquinaExistente.Nome = maquina.Nome;
                maquinaExistente.TipoMaquinaId = maquina.TipoMaquinaId;
                maquinaExistente.SetorId = maquina.SetorId;
                maquinaExistente.Modelo = maquina.Modelo;
                maquinaExistente.NumeroSerie = maquina.NumeroSerie;
                maquinaExistente.FabricanteId = maquina.FabricanteId;
                maquinaExistente.DataAquisicao = maquina.DataAquisicao;
                maquinaExistente.FotoUrl = maquina.FotoUrl;
                maquinaExistente.Peso = maquina.Peso;
                maquinaExistente.Voltagem = maquina.Voltagem;
                await _dbContext.SaveChangesAsync();
            }
            return maquinaExistente;
        }

        public async Task<bool> DeleteMaquina(int id)
        {
            MaquinaModel maquina = await GetById(id);
            if (maquina == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Maquina.Remove(maquina);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
