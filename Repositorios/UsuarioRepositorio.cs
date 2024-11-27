using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiGHMM.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio 
    {
        private readonly Contexto _dbContext;

        public UsuarioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<UsuarioModel> InsertUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Login(string cpf, string password)
        {
            var result = await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioSenha == password &&  x.UsuarioCpf == cpf);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<UsuarioModel> UpdateUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioExistente = await GetById(id);
            if (usuarioExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                usuarioExistente.UsuarioNome = usuario.UsuarioNome;
                usuarioExistente.FotoUrl = usuario.FotoUrl;
                usuarioExistente.UsuarioEmail = usuario.UsuarioEmail;
                usuarioExistente.UsuarioCpf = usuario.UsuarioCpf;
                usuarioExistente.UsuarioTelefone = usuario.UsuarioTelefone;
                usuarioExistente.UsuarioDataNascimento = usuario.UsuarioDataNascimento;
                usuarioExistente.UsuarioSenha = usuario.UsuarioSenha;
                usuarioExistente.CargoId = usuario.CargoId;
                usuarioExistente.SetorId = usuario.SetorId;
                _dbContext.Usuario.Update(usuarioExistente);
                await _dbContext.SaveChangesAsync();
            }
            return usuarioExistente;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            UsuarioModel usuario = await GetById(id);
            if (usuario == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Usuario.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
