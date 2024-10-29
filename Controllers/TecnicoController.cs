using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        private readonly ITecnicoRepositorio _tecnicoRepositorio;

        public TecnicoController(ITecnicoRepositorio tecnicoRepositorio)
        {
            _tecnicoRepositorio = tecnicoRepositorio;
        }

        [HttpGet("GetAllTecnicos")]
        public async Task<ActionResult<List<TecnicosModel>>> GetAllTecnicos()
        {
            List<TecnicosModel> tecnicos = await _tecnicoRepositorio.GetAll();
            return Ok(tecnicos);
        }

        [HttpGet("GetTecnicoById/{id}")]
        public async Task<ActionResult<TecnicosModel>> GetTecnicoById(int id)
        {
            TecnicosModel tecnico = await _tecnicoRepositorio.GetById(id);
            if (tecnico == null)
            {
                return NotFound();
            }
            return Ok(tecnico);
        }

        [HttpPost("CreateTecnico")]
        public async Task<ActionResult<TecnicosModel>> InsertTecnico([FromBody] TecnicosModel tecnicoModel)
        {
            TecnicosModel tecnico = await _tecnicoRepositorio.InsertTecnico(tecnicoModel);
            return CreatedAtAction(nameof(GetTecnicoById), new { id = tecnico.TecnicosId }, tecnico);
        }

        [HttpPut("UpdateCargo/{id:int}")]
        public async Task<ActionResult<TecnicosModel>> UpdateTecnico(int id, [FromBody] TecnicosModel tecnicoModel)
        {
            tecnicoModel.TecnicosId = id;
            TecnicosModel cargo = await _tecnicoRepositorio.UpdateTecnico(tecnicoModel, id);
            return Ok(cargo);
        }

        [HttpDelete("DeleteTecnico/{id:int}")]
        public async Task<ActionResult> DeleteTecnico(int id)
        {
            bool deleted = await _tecnicoRepositorio.DeleteTecnico(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
