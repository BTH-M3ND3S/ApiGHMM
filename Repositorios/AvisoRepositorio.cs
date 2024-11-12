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

        public async Task<List<AvisoCompleto>> GetAll()
        {
             var teste = await _dbContext.Aviso
                 .Join(_dbContext.Usuario,
                    aviso => aviso.UsuarioId,
                    usuario => usuario.UsuarioId,
                    (aviso, usuario) => new { aviso, usuario })
                 .Join(_dbContext.AvisoTipo,
                    aviso => aviso.aviso.AvisoTipoId,
                    avisotipo => avisotipo.AvisoTipoId,
                    (aviso, avisotipo) => new AvisoCompleto
                    {
                        AvisoId = aviso.aviso.AvisoId,
                        AvisoConteudo = aviso.aviso.AvisoConteudo,
                        AvisoVisto = aviso.aviso.AvisoVisto,
                        Usuario = new UsuarioModel
                        {
                            UsuarioId = aviso.usuario.UsuarioId,
                            FotoUrl = aviso.usuario.FotoUrl,
                            UsuarioNome = aviso.usuario.UsuarioNome,
                            UsuarioCpf = aviso.usuario.UsuarioCpf,
                            UsuarioEmail = aviso.usuario.UsuarioEmail,
                            UsuarioTelefone = aviso.usuario.UsuarioTelefone,
                            UsuarioDataNascimento = aviso.usuario.UsuarioDataNascimento,
                            UsuarioEscolaridade = aviso.usuario.UsuarioEscolaridade,
                            UsuarioSenha = aviso.usuario.UsuarioSenha,
                            CargoId = aviso.usuario.CargoId,
                            SetorId = aviso.usuario.SetorId,
                        },
                        AvisoTipo = new AvisoTipoModel
                        {
                            AvisoTipoId = avisotipo.AvisoTipoId,
                            AvisoTipoNome = avisotipo.AvisoTipoNome,
                        }
                    }).ToListAsync();
            return teste;
        }

        public async Task<AvisoModel> GetById(int id)
        {
            return await _dbContext.Aviso.FirstOrDefaultAsync(x => x.AvisoId == id);
        }

        public async Task<AvisoCompleto> GetByIdCompleto(int id)
        {
            var teste = await _dbContext.Aviso
                 .Join(_dbContext.Usuario,
                    aviso => aviso.UsuarioId,
                    usuario => usuario.UsuarioId,
                    (aviso, usuario) => new { aviso, usuario })
                 .Join(_dbContext.AvisoTipo,
                    aviso => aviso.aviso.AvisoTipoId,
                    avisotipo => avisotipo.AvisoTipoId,
                    (aviso, avisotipo) => new AvisoCompleto
                    {
                        AvisoId = aviso.aviso.AvisoId,
                        AvisoConteudo = aviso.aviso.AvisoConteudo,
                        AvisoVisto = aviso.aviso.AvisoVisto,
                        Usuario = new UsuarioModel
                        {
                            UsuarioId = aviso.usuario.UsuarioId,
                            FotoUrl = aviso.usuario.FotoUrl,
                            UsuarioNome = aviso.usuario.UsuarioNome,
                            UsuarioCpf = aviso.usuario.UsuarioCpf,
                            UsuarioEmail = aviso.usuario.UsuarioEmail,
                            UsuarioTelefone = aviso.usuario.UsuarioTelefone,
                            UsuarioDataNascimento = aviso.usuario.UsuarioDataNascimento,
                            UsuarioEscolaridade = aviso.usuario.UsuarioEscolaridade,
                            UsuarioSenha = aviso.usuario.UsuarioSenha,
                            CargoId = aviso.usuario.CargoId,
                            SetorId = aviso.usuario.SetorId,
                        },
                        AvisoTipo = new AvisoTipoModel
                        {
                            AvisoTipoId = avisotipo.AvisoTipoId,
                            AvisoTipoNome = avisotipo.AvisoTipoNome,
                        }
                    }).FirstOrDefaultAsync(x => x.AvisoId == id);
            return teste;
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
                avisoExistente.UsuarioId = aviso.UsuarioId;
                avisoExistente.AvisoTipoId = aviso.AvisoTipoId;
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
