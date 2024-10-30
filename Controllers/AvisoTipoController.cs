using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvisoTipoController : ControllerBase
    {
        private readonly IAvisoTipoRepositorio _avisoTipoRepositorio;

        public AvisoTipoController(IAvisoTipoRepositorio avisoTipoRepositorio)
        {
            _avisoTipoRepositorio = avisoTipoRepositorio;
        }

        [HttpGet("GetAllAvisoTipos")]
        public async Task<ActionResult<List<AvisoTipoModel>>> GetAllAvisoTipos()
        {
            List<AvisoTipoModel> avisoTipos = await _avisoTipoRepositorio.GetAll();
            return Ok(avisoTipos);
        }

        [HttpGet("GetAvisoTipoById/{id}")]
        public async Task<ActionResult<AvisoTipoModel>> GetAvisoTipoById(int id)
        {
            AvisoTipoModel avisoTipo = await _avisoTipoRepositorio.GetById(id);
            if (avisoTipo == null)
            {
                return NotFound();
            }
            return Ok(avisoTipo);
        }

        [HttpPost("CreateAvisoTipo")]
        public async Task<ActionResult<AvisoTipoModel>> InsertAvisoTipo([FromBody] AvisoTipoModel avisoTipoModel)
        {
            AvisoTipoModel avisoTipo = await _avisoTipoRepositorio.InsertAvisoTipo(avisoTipoModel);
            return CreatedAtAction(nameof(GetAvisoTipoById), new { id = avisoTipo.AvisoTipoId }, avisoTipo);
        }

        [HttpPut("UpdateAvisoTipo/{id:int}")]
        public async Task<ActionResult<AvisoTipoModel>> UpdateAvisoTipo(int id, [FromBody] AvisoTipoModel avisoTipoModel)
        {
            avisoTipoModel.AvisoTipoId = id;
            AvisoTipoModel avisoTipo = await _avisoTipoRepositorio.UpdateAvisoTipo(avisoTipoModel, id);
            return Ok(avisoTipo);
        }

        [HttpDelete("DeleteAvisoTipo/{id:int}")]
        public async Task<ActionResult> DeleteAvisoTipo(int id)
        {
            bool deleted = await _avisoTipoRepositorio.DeleteAvisoTipo(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
