using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioRepositorio _relatorioRepositorio;

        public RelatorioController(IRelatorioRepositorio relatorioRepositorio)
        {
            _relatorioRepositorio = relatorioRepositorio;
        }

        [HttpGet("GetAllRelatorios")]
        public async Task<ActionResult<List<RelatorioModel>>> GetAllRelatorios()
        {
            List<RelatorioModel> relatorios = await _relatorioRepositorio.GetAll();
            return Ok(relatorios);
        }

        [HttpGet("GetRelatorioById/{id}")]
        public async Task<ActionResult<RelatorioModel>> GetRelatorioById(int id)
        {
            RelatorioModel relatorio = await _relatorioRepositorio.GetById(id);
            if (relatorio == null)
            {
                return NotFound();
            }
            return Ok(relatorio);
        }

        [HttpPost("CreateRelatorio")]
        public async Task<ActionResult<RelatorioModel>> InsertRelatorio([FromBody] RelatorioModel relatorioModel)
        {
            RelatorioModel relatorio = await _relatorioRepositorio.InsertRelatorio(relatorioModel);
            return CreatedAtAction(nameof(GetRelatorioById), new { id = relatorio.RelatorioId }, relatorio);
        }

        [HttpPut("UpdateRelatorio/{id:int}")]
        public async Task<ActionResult<RelatorioModel>> UpdateRelatorio(int id, [FromBody] RelatorioModel relatorioModel)
        {
            relatorioModel.RelatorioId = id;
            RelatorioModel relatorio = await _relatorioRepositorio.UpdateRelatorio(relatorioModel, id);
            return Ok(relatorio);
        }

        [HttpDelete("DeleteRelatorio/{id:int}")]
        public async Task<ActionResult> DeleteRelatorio(int id)
        {
            bool deleted = await _relatorioRepositorio.DeleteRelatorio(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
