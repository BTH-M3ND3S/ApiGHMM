using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoManutencaoController : ControllerBase
    {
        private readonly ITipoManutencaoRepositorio _tipoManutencaoRepositorio;

        public TipoManutencaoController(ITipoManutencaoRepositorio tipoManutencaoRepositorio)
        {
            _tipoManutencaoRepositorio = tipoManutencaoRepositorio;
        }

        [HttpGet("GetAllTipoManutencao")]
        public async Task<ActionResult<List<TipoManutencaoModel>>> GetAllTipoManutencao()
        {
            List<TipoManutencaoModel> tipoManutencao = await _tipoManutencaoRepositorio.GetAll();
            return Ok(tipoManutencao);
        }

        [HttpGet("GetTipoManutencaoById/{id}")]
        public async Task<ActionResult<TipoManutencaoModel>> GetTipoManutencaoById(int id)
        {
            TipoManutencaoModel tipoManutencao = await _tipoManutencaoRepositorio.GetById(id);
            if (tipoManutencao == null)
            {
                return NotFound();
            }
            return Ok(tipoManutencao);
        }

        [HttpPost("CreateTipoManutencao")]
        public async Task<ActionResult<TipoManutencaoModel>> InsertTipoManutencao([FromBody] TipoManutencaoModel tipoManutencaoModel)
        {
            if (tipoManutencaoModel == null)
            {
                return BadRequest("Tipo de manutenção não pode ser nulo.");
            }

            TipoManutencaoModel tipoManutencao = await _tipoManutencaoRepositorio.InsertTipoManutencao(tipoManutencaoModel);
            return CreatedAtAction(nameof(GetTipoManutencaoById), new { id = tipoManutencao.TipoManutencaoId }, tipoManutencao);
        }

        [HttpPut("UpdateTipoManutencao/{id:int}")]
        public async Task<ActionResult<TipoManutencaoModel>> UpdateTipoManutencao(int id, [FromBody] TipoManutencaoModel tipoManutencaoModel)
        {
            if (tipoManutencaoModel == null)
            {
                return BadRequest("Tipo de manutenção não pode ser nulo.");
            }

            tipoManutencaoModel.TipoManutencaoId = id;
            TipoManutencaoModel tipoManutencao = await _tipoManutencaoRepositorio.UpdateTipoManutencao(tipoManutencaoModel, id);
            if (tipoManutencao == null)
            {
                return NotFound();
            }
            return Ok(tipoManutencao);
        }

        [HttpDelete("DeleteTipoManutencao/{id:int}")]
        public async Task<ActionResult> DeleteTipoManutencao(int id)
        {
            bool deleted = await _tipoManutencaoRepositorio.DeleteTipoManutencao(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
