using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGHMM.Repositorios
{
    public class PecaRepositorio : IPecaRepositorio
    {
        private readonly Contexto _dbContext;

        public PecaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<PecaModel>> GetAll()
        {
            return await _dbContext.Peca.ToListAsync();
        }

        public async Task<PecaModel> GetById(int id)
        {
            return await _dbContext.Peca.FirstOrDefaultAsync(x => x.PecaId == id);
        }

        public async Task<PecaModel> InsertPeca(PecaModel peca)
        {
            if (peca == null)
            {
                throw new ArgumentNullException(nameof(peca));
            }

            await _dbContext.Peca.AddAsync(peca);
            await _dbContext.SaveChangesAsync();
            return peca;
        }

        public async Task<PecaModel> UpdatePeca(PecaModel peca, int id)
        {
            if (peca == null)
            {
                throw new ArgumentNullException(nameof(peca));
            }

            var pecaExistente = await GetById(id);
            if (pecaExistente == null)
            {
                throw new Exception("Peça não encontrada.");
            }

            // Atualize as propriedades conforme necessário
            pecaExistente.PecaNome = peca.PecaNome;
            pecaExistente.QuantidadeEstoque = peca.QuantidadeEstoque;

            await _dbContext.SaveChangesAsync();
            return pecaExistente;
        }

        public async Task<bool> DeletePeca(int id)
        {
            var peca = await GetById(id);
            if (peca == null)
            {
                throw new Exception("Peça não encontrada.");
            }

            _dbContext.Peca.Remove(peca);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
