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
    public class ManutencaoEPecasController : ControllerBase
    {
        private readonly IManutencaoEPecasRepositorio _manutencaoEPecasRepositorio;

        public ManutencaoEPecasController(IManutencaoEPecasRepositorio manutencaoEPecasRepositorio)
        {
            _manutencaoEPecasRepositorio = manutencaoEPecasRepositorio;
        }

        [HttpGet("GetAllManutencaoEPecas")]
        public async Task<ActionResult<List<ManutencaoEPecasModel>>> GetAllManutencaoEPecas()
        {
            List<ManutencaoEPecasModel> manutencaoEPecas = await _manutencaoEPecasRepositorio.GetAll();
            return Ok(manutencaoEPecas);
        }

        [HttpGet("GetManutencaoEPecasById/{id}")]
        public async Task<ActionResult<ManutencaoEPecasModel>> GetManutencaoEPecasById(int id)
        {
            ManutencaoEPecasModel manutencaoEPecas = await _manutencaoEPecasRepositorio.GetById(id);
            if (manutencaoEPecas == null)
            {
                return NotFound();
            }
            return Ok(manutencaoEPecas);
        }

        [HttpPost("CreateManutencaoEPecas")]
        public async Task<ActionResult<ManutencaoEPecasModel>> InsertManutencaoEPecas([FromBody] ManutencaoEPecasModel manutencaoEPecasModel)
        {
            ManutencaoEPecasModel manutencaoEPecas = await _manutencaoEPecasRepositorio.InsertManutencaoEPecas(manutencaoEPecasModel);
            return CreatedAtAction(nameof(GetManutencaoEPecasById), new { id = manutencaoEPecas.ManutencaoEPecasId }, manutencaoEPecas);
        }

        [HttpPut("UpdateManutencaoEPecas/{id:int}")]
        public async Task<ActionResult<ManutencaoEPecasModel>> UpdateManutencaoEPecas(int id, [FromBody] ManutencaoEPecasModel manutencaoEPecasModel)
        {
            manutencaoEPecasModel.ManutencaoEPecasId = id;
            ManutencaoEPecasModel manutencaoEPecas = await _manutencaoEPecasRepositorio.UpdateManutencaoEPecas(manutencaoEPecasModel, id);
            return Ok(manutencaoEPecas);
        }

        [HttpDelete("DeleteManutencaoEPecas/{id:int}")]
        public async Task<ActionResult> DeleteManutencaoEPecas(int id)
        {
            bool deleted = await _manutencaoEPecasRepositorio.DeleteManutencaoEPecas(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
