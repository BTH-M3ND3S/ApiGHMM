using ApiGHMM.Data;
using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGHMM.Repositorios
{
    public class CargoRepositorio : ICargoRepositorio
    {
        private readonly Contexto _dbContext;

        public CargoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CargoModel>> GetAll()
        {
            return await _dbContext.Cargo.ToListAsync();
        }

        public async Task<CargoModel> GetById(int id)
        {
            return await _dbContext.Cargo.FirstOrDefaultAsync(x => x.CargoId == id);
        }

        public async Task<CargoModel> InsertCargo(CargoModel cargo)
        {
            await _dbContext.Cargo.AddAsync(cargo);
            await _dbContext.SaveChangesAsync();
            return cargo;
        }

        public async Task<CargoModel> UpdateCargo(CargoModel cargo, int id)
        {
            CargoModel cargoExistente = await GetById(id);
            if (cargoExistente == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                cargoExistente.CargoNome = cargo.CargoNome;
                await _dbContext.SaveChangesAsync();
            }
            return cargoExistente;
        }

        public async Task<bool> DeleteCargo(int id)
        {
            CargoModel cargo = await GetById(id);
            if (cargo == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Cargo.Remove(cargo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
