﻿using ApiGHMM.Models;

namespace ApiGHMM.Repositorios.Interfaces
{
    public interface IMaquinaRepositorio
    {
        Task<List<MaquinaModel>> GetAll();

        Task<MaquinaModel> GetById(int id);

        Task<MaquinaModel> InsertMaquina(MaquinaModel maquina);

        Task<MaquinaModel> UpdateMaquina(MaquinaModel maquina, int id);

        Task<bool> DeleteMaquina(int id);
    }
}
