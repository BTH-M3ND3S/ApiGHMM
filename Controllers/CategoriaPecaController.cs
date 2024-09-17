using ApiGHMM.Models;
using ApiGHMM.Repositorios;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaPecaController : ControllerBase
    {
        private readonly ICategoriaPecaRepositorio _categoriaPecaRepositorio;

        public CategoriaPecaController(ICategoriaPecaRepositorio categoriaPecaRepositorio)
        {
            _categoriaPecaRepositorio = categoriaPecaRepositorio;
        }

        [HttpGet("GetAllCategoriaPecas")]
        public async Task<ActionResult<List<CategoriaPecaModel>>> GetAllCategoriaPecas()
        {
            List<CategoriaPecaModel> categoriaPecas = await _categoriaPecaRepositorio.GetAll();
            return Ok(categoriaPecas);
        }

        [HttpGet("GetCategoriaPecaById/{id}")]
        public async Task<ActionResult<CategoriaPecaModel>> GetCategoriaPecaById(int id)
        {
            CategoriaPecaModel categoriaPeca = await _categoriaPecaRepositorio.GetById(id);
            if (categoriaPeca == null)
            {
                return NotFound();
            }
            return Ok(categoriaPeca);
        }

        [HttpPost("CreateCategoriaPeca")]
        public async Task<ActionResult<CategoriaPecaModel>> InsertCategoriaPeca([FromBody] CategoriaPecaModel categoriaPecaModel)
        {
            CategoriaPecaModel categoriaPeca = await _categoriaPecaRepositorio.InsertCategoriaPeca(categoriaPecaModel);
            return CreatedAtAction(nameof(GetCategoriaPecaById), new { id = categoriaPeca.CategoriaPecaId }, categoriaPeca);
        }

        [HttpPut("UpdateCategoriaPeca/{id:int}")]
        public async Task<ActionResult<CategoriaPecaModel>> UpdateCategoriaPeca(int id, [FromBody] CategoriaPecaModel categoriaPecaModel)
        {
            categoriaPecaModel.CategoriaPecaId = id;
            CategoriaPecaModel categoriaPeca = await _categoriaPecaRepositorio.UpdateCategoriaPeca(categoriaPecaModel, id);
            return Ok(categoriaPeca);
        }

        [HttpDelete("DeleteCategoriaPeca/{id:int}")]
        public async Task<ActionResult> DeleteCategoriaPeca(int id)
        {
            bool deleted = await _categoriaPecaRepositorio.DeleteCategoriaPeca(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
