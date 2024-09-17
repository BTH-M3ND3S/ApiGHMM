using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiGHMM.Repositorios
{
    public class FuncionariosRepositorio : IFuncionariosRepositorio 
    {
        private readonly Contexto _dbContext;

        public FuncionariosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FuncionarioModel>> GetAll()
        {
            return await _dbContext.Funcionario.ToListAsync();
        }

        public async Task<FuncionarioModel> GetById(int id)
        {
            return await _dbContext.Funcionario.FirstOrDefaultAsync(x => x.FuncionarioId == id);
        }

        public async Task<FuncionarioModel> InsertFuncionario(FuncionarioModel funcionario)
        {
            await _dbContext.Funcionario.AddAsync(funcionario);
            await _dbContext.SaveChangesAsync();
            return funcionario;
        }

        public async Task<FuncionarioModel> UpdateFuncionario(FuncionarioModel funcionario, int id)
        {
            FuncionarioModel funcionarioExistente = await GetById(id);
            if (funcionarioExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                funcionarioExistente.FuncionarioNome = funcionario.FuncionarioNome;
                funcionarioExistente.FotoUrl = funcionario.FotoUrl;
                funcionarioExistente.FuncionarioEmail = funcionario.FuncionarioEmail;
                funcionarioExistente.FuncionarioCpf = funcionario.FuncionarioCpf;
                funcionarioExistente.FuncionarioTelefone = funcionario.FuncionarioTelefone;
                funcionarioExistente.FuncionarioDataNascimento = funcionario.FuncionarioDataNascimento;
                funcionarioExistente.FuncionarioSenha = funcionario.FuncionarioSenha;
                funcionarioExistente.CargoId = funcionario.CargoId;
                funcionarioExistente.SetorId = funcionario.SetorId;
                _dbContext.Funcionario.Update(funcionarioExistente);
                await _dbContext.SaveChangesAsync();
            }
            return funcionarioExistente;
        }

        public async Task<bool> DeleteFuncionario(int id)
        {
            FuncionarioModel funcionario = await GetById(id);
            if (funcionario == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Funcionario.Remove(funcionario);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
