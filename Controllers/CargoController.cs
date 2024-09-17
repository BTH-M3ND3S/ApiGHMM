using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoRepositorio _cargoRepositorio;

        public CargoController(ICargoRepositorio cargoRepositorio)
        {
            _cargoRepositorio = cargoRepositorio;
        }

        [HttpGet("GetAllCargos")]
        public async Task<ActionResult<List<CargoModel>>> GetAllCargos()
        {
            List<CargoModel> cargos = await _cargoRepositorio.GetAll();
            return Ok(cargos);
        }

        [HttpGet("GetCargoById/{id}")]
        public async Task<ActionResult<CargoModel>> GetCargoById(int id)
        {
            CargoModel cargo = await _cargoRepositorio.GetById(id);
            if (cargo == null)
            {
                return NotFound();
            }
            return Ok(cargo);
        }

        [HttpPost("CreateCargo")]
        public async Task<ActionResult<CargoModel>> InsertCargo([FromBody] CargoModel cargoModel)
        {
            CargoModel cargo = await _cargoRepositorio.InsertCargo(cargoModel);
            return CreatedAtAction(nameof(GetCargoById), new { id = cargo.CargoId }, cargo);
        }

        [HttpPut("UpdateCargo/{id:int}")]
        public async Task<ActionResult<CargoModel>> UpdateCargo(int id, [FromBody] CargoModel cargoModel)
        {
            cargoModel.CargoId = id;
            CargoModel cargo = await _cargoRepositorio.UpdateCargo(cargoModel, id);
            return Ok(cargo);
        }

        [HttpDelete("DeleteCargo/{id:int}")]
        public async Task<ActionResult> DeleteCargo(int id)
        {
            bool deleted = await _cargoRepositorio.DeleteCargo(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
