using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoTipoController : ControllerBase
    {
        private readonly ITecnicoTipoRepositorio _tecnicoTipoRepositorio;

        public TecnicoTipoController(ITecnicoTipoRepositorio tecnicoTipoRepositorio)
        {
            _tecnicoTipoRepositorio = tecnicoTipoRepositorio;
        }

        [HttpGet("GetAllTecnicoTipo")]
        public async Task<ActionResult<List<TecnicoTipoModel>>> GetAllTecnicoTipo()
        {
            List<TecnicoTipoModel> tecnicoTipo = await _tecnicoTipoRepositorio.GetAll();
            return Ok(tecnicoTipo);
        }

        [HttpGet("GetTecnicoTipoById/{id}")]
        public async Task<ActionResult<TecnicoTipoModel>> GetTecnicoTipoById(int id)
        {
            TecnicoTipoModel tecnicoTipo = await _tecnicoTipoRepositorio.GetById(id);
            if (tecnicoTipo == null)
            {
                return NotFound();
            }
            return Ok(tecnicoTipo);
        }

        [HttpPost("CreateTecnicoTipo")]
        public async Task<ActionResult<TecnicoTipoModel>> InsertTecnicoTipo([FromBody] TecnicoTipoModel tecnicoTipoModel)
        {
            TecnicoTipoModel tecnicoTipo = await _tecnicoTipoRepositorio.InsertTecnicoTipo(tecnicoTipoModel);
            return CreatedAtAction(nameof(GetTecnicoTipoById), new { id = tecnicoTipo.TecnicoTipoId }, tecnicoTipo);
        }

        [HttpPut("UpdateTecnicoTipo/{id:int}")]
        public async Task<ActionResult<TecnicoTipoModel>> UpdateTecnicoTipo(int id, [FromBody] TecnicoTipoModel tecnicoTipoModel)
        {
            tecnicoTipoModel.TecnicoTipoId = id;
            TecnicoTipoModel tecnicoTipo = await _tecnicoTipoRepositorio.UpdateTecnicoTipo(tecnicoTipoModel, id);
            return Ok(tecnicoTipo);
        }

        [HttpDelete("DeleteTecnicoTipo/{id:int}")]
        public async Task<ActionResult> DeleteTecnicoTipo(int id)
        {
            bool deleted = await _tecnicoTipoRepositorio.DeleteTecnicoTipo(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
