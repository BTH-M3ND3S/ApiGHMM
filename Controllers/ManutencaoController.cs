using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManutencaoController : ControllerBase
    {
        private readonly IManutencaoRepositorio _manutencaoRepositorio;

        public ManutencaoController(IManutencaoRepositorio manutencaoRepositorio)
        {
            _manutencaoRepositorio = manutencaoRepositorio;
        }

        [HttpGet("GetAllManutencao")]
        public async Task<ActionResult<List<ManutencaoModel>>> GetAllManutencao()
        {
            List<ManutencaoModel> manutencao = await _manutencaoRepositorio.GetAll();
            return Ok(manutencao);
        }

        [HttpGet("GetManutencaoById/{id}")]
        public async Task<ActionResult<ManutencaoModel>> GetManutencaoById(int id)
        {
            ManutencaoModel manutencao = await _manutencaoRepositorio.GetById(id);
            if (manutencao == null)
            {
                return NotFound();
            }
            return Ok(manutencao);
        }

        [HttpPost("CreateManutencao")]
        public async Task<ActionResult<ManutencaoModel>> InsertManutencao([FromBody] ManutencaoModel manutencaoModel)
        {
            ManutencaoModel manutencao = await _manutencaoRepositorio.InsertManutencao(manutencaoModel);
            return CreatedAtAction(nameof(GetManutencaoById), new { id = manutencao.ManutencaoId }, manutencao);
        }

        [HttpPut("UpdateManutencao/{id:int}")]
        public async Task<ActionResult<ManutencaoModel>> UpdateManutencao(int id, [FromBody] ManutencaoModel manutencaoModel)
        {
            manutencaoModel.ManutencaoId = id;
            ManutencaoModel manutencao = await _manutencaoRepositorio.UpdateManutencao(manutencaoModel, id);
            return Ok(manutencao);
        }

        [HttpDelete("DeleteManutencao/{id:int}")]
        public async Task<ActionResult> DeleteManutencao(int id)
        {
            bool deleted = await _manutencaoRepositorio.DeleteManutencao(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
