using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvisoController : ControllerBase
    {
        private readonly IAvisoRepositorio _avisoRepositorio;

        public AvisoController(IAvisoRepositorio avisoRepositorio)
        {
            _avisoRepositorio = avisoRepositorio;
        }

        [HttpGet("GetAllAvisos")]
        public async Task<ActionResult<List<AvisoModel>>> GetAllAvisos()
        {
            List<AvisoModel> avisos = await _avisoRepositorio.GetAll();
            return Ok(avisos);
        }

        [HttpGet("GetAvisoById/{id}")]
        public async Task<ActionResult<AvisoModel>> GetAvisoById(int id)
        {
            AvisoModel aviso = await _avisoRepositorio.GetById(id);
            if (aviso == null)
            {
                return NotFound();
            }
            return Ok(aviso);
        }

        [HttpPost("CreateAviso")]
        public async Task<ActionResult<AvisoModel>> InsertAviso([FromBody] AvisoModel avisoModel)
        {
            AvisoModel aviso = await _avisoRepositorio.InsertAviso(avisoModel);
            return CreatedAtAction(nameof(GetAvisoById), new { id = aviso.AvisoId }, aviso);
        }

        [HttpPut("UpdateAviso/{id:int}")]
        public async Task<ActionResult<AvisoModel>> UpdateAviso(int id, [FromBody] AvisoModel avisoModel)
        {
            avisoModel.AvisoId = id;
            AvisoModel aviso = await _avisoRepositorio.UpdateAviso(avisoModel, id);
            return Ok(aviso);
        }

        [HttpDelete("DeleteAviso/{id:int}")]
        public async Task<ActionResult> DeleteAviso(int id)
        {
            bool deleted = await _avisoRepositorio.DeleteAviso(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
