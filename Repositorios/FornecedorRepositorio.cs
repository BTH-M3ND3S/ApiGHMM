using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly Contexto _dbContext;

        public FornecedorRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FornecedorModel>> GetAll()
        {
            return await _dbContext.Fornecedor.ToListAsync();
        }

        public async Task<FornecedorModel> GetById(int id)
        {
            return await _dbContext.Fornecedor.FirstOrDefaultAsync(x => x.FornecedorId == id);
        }

        public async Task<FornecedorModel> InsertFornecedor(FornecedorModel fornecedor)
        {
            await _dbContext.Fornecedor.AddAsync(fornecedor);
            await _dbContext.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<FornecedorModel> UpdateFornecedor(FornecedorModel fornecedor, int id)
        {
            FornecedorModel fornecedorExistente = await GetById(id);
            if (fornecedorExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                fornecedorExistente.FornecedorNome = fornecedor.FornecedorNome;
                fornecedorExistente.FornecedorCnpj = fornecedor.FornecedorCnpj;
                await _dbContext.SaveChangesAsync();
            }
            return fornecedorExistente;
        }

        public async Task<bool> DeleteFornecedor(int id)
        {
            FornecedorModel fornecedor = await GetById(id);
            if (fornecedor == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Fornecedor.Remove(fornecedor);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
