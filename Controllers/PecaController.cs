using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecaController : ControllerBase
    {
        private readonly IPecaRepositorio _pecaRepositorio;

        public PecaController(IPecaRepositorio pecaRepositorio)
        {
            _pecaRepositorio = pecaRepositorio;
        }

        [HttpGet("GetAllPecas")]
        public async Task<ActionResult<List<PecaModel>>> GetAllPecas()
        {
            List<PecaModel> pecas = await _pecaRepositorio.GetAll();
            return Ok(pecas);
        }

        [HttpGet("GetPecaById/{id}")]
        public async Task<ActionResult<PecaModel>> GetPecaById(int id)
        {
            PecaModel peca = await _pecaRepositorio.GetById(id);
            if (peca == null)
            {
                return NotFound();
            }
            return Ok(peca);
        }

        [HttpPost("CreatePeca")]
        public async Task<ActionResult<PecaModel>> InsertPeca([FromBody] PecaModel pecaModel)
        {
            PecaModel peca = await _pecaRepositorio.InsertPeca(pecaModel);
            return CreatedAtAction(nameof(GetPecaById), new { id = peca.PecaId }, peca);
        }

        [HttpPut("UpdatePeca/{id:int}")]
        public async Task<ActionResult<PecaModel>> UpdatePeca(int id, [FromBody] PecaModel pecaModel)
        {
            pecaModel.PecaId = id;
            PecaModel peca = await _pecaRepositorio.UpdatePeca(pecaModel, id);
            return Ok(peca);
        }

        [HttpDelete("DeletePeca/{id:int}")]
        public async Task<ActionResult> DeletePeca(int id)
        {
            bool deleted = await _pecaRepositorio.DeletePeca(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}