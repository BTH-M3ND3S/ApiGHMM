using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMaquinaController : ControllerBase
    {
        private readonly ITipoMaquinaRepositorio _tipoMaquinaRepositorio;

        public TipoMaquinaController(ITipoMaquinaRepositorio tipoMaquinaRepositorio)
        {
            _tipoMaquinaRepositorio = tipoMaquinaRepositorio;
        }

        [HttpGet("GetAllTipoMaquinas")]
        public async Task<ActionResult<List<TipoMaquinaModel>>> GetAllTipoMaquinas()
        {
            List<TipoMaquinaModel> tipoMaquinas = await _tipoMaquinaRepositorio.GetAll();
            return Ok(tipoMaquinas);
        }

        [HttpGet("GetTipoMaquinaById/{id}")]
        public async Task<ActionResult<TipoMaquinaModel>> GetTipoMaquinaById(int id)
        {
            TipoMaquinaModel tipoMaquina = await _tipoMaquinaRepositorio.GetById(id);
            if (tipoMaquina == null)
            {
                return NotFound();
            }
            return Ok(tipoMaquina);
        }

        [HttpPost("CreateTipoMaquina")]
        public async Task<ActionResult<TipoMaquinaModel>> InsertTipoMaquina([FromBody] TipoMaquinaModel tipoMaquinaModel)
        {
            TipoMaquinaModel tipoMaquina = await _tipoMaquinaRepositorio.InsertTipoMaquina(tipoMaquinaModel);
            return CreatedAtAction(nameof(GetTipoMaquinaById), new { id = tipoMaquina.TipoMaquinaId }, tipoMaquina);
        }

        [HttpPut("UpdateTipoMaquina/{id:int}")]
        public async Task<ActionResult<TipoMaquinaModel>> UpdateTipoMaquina(int id, [FromBody] TipoMaquinaModel tipoMaquinaModel)
        {
            tipoMaquinaModel.TipoMaquinaId = id;
            TipoMaquinaModel tipoMaquina = await _tipoMaquinaRepositorio.UpdateTipoMaquina(tipoMaquinaModel, id);
            return Ok(tipoMaquina);
        }

        [HttpDelete("DeleteTipoMaquina/{id:int}")]
        public async Task<ActionResult> DeleteTipoMaquina(int id)
        {
            bool deleted = await _tipoMaquinaRepositorio.DeleteTipoMaquina(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
