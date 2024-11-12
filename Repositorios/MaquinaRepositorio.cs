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

        public async Task<MaquinaCompleto> GetByNumeroSerie(string numeroSerie)
        {
            var teste =  await _dbContext.Maquina
                 .Join( _dbContext.Fabricante, 
                    maquina => maquina.FabricanteId,
                    fabricante => fabricante.FabricanteId,
                    ( maquina, fabricante ) => new { maquina, fabricante } )
                 .Join( _dbContext.TipoMaquina, 
                    maquina => maquina.maquina.TipoMaquinaId,
                    tipoMaquina => tipoMaquina.TipoMaquinaId,
                    ( maquina , tipoMaquina) => new {maquina, tipoMaquina } )
                 .Join(_dbContext.Setor,
                        m => m.maquina.maquina.SetorId,
                        setor => setor.SetorId,
                        (m, setor) => new MaquinaCompleto
                        {
                            MaquinaId = m.maquina.maquina.MaquinaId,
                            Nome = m.maquina.maquina.Nome,
                            Modelo = m.maquina.maquina.Modelo,
                            NumeroSerie = m.maquina.maquina.NumeroSerie,
                            DataAquisicao = m.maquina.maquina.DataAquisicao,
                            FotoUrl = m.maquina.maquina.FotoUrl,
                            Peso = m.maquina.maquina.Peso,
                            Voltagem = m.maquina.maquina.Voltagem,
                            MaquinaDetalhes = m.maquina.maquina.MaquinaDetalhes,
                            Setor = new SetorModel
                            {
                                SetorId = setor.SetorId,
                                SetorNome = setor.SetorNome
                            },
                            Fabricante = new FabricanteModel
                            {
                                FabricanteId = m.maquina.fabricante.FabricanteId,
                                FabricanteNome = m.maquina.fabricante.FabricanteNome
                            },
                            TipoMaquina = new TipoMaquinaModel
                            {
                                TipoMaquinaId = m.tipoMaquina.TipoMaquinaId,
                                TipoMaquinaNome = m.tipoMaquina.TipoMaquinaNome
                            }
                        }).FirstOrDefaultAsync( x => x.NumeroSerie.Equals( numeroSerie ) );

            return teste;
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
                maquinaExistente.MaquinaDetalhes = maquina.MaquinaDetalhes;
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
