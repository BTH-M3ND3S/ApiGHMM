using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly IFabricanteRepositorio _fabricanteRepositorio;

        public FabricanteController(IFabricanteRepositorio fabricanteRepositorio)
        {
            _fabricanteRepositorio = fabricanteRepositorio;
        }

        [HttpGet("GetAllFabricantes")]
        public async Task<ActionResult<List<FabricanteModel>>> GetAllFabricantes()
        {
            List<FabricanteModel> fabricantes = await _fabricanteRepositorio.GetAll();
            return Ok(fabricantes);
        }

        [HttpGet("GetFabricanteById/{id}")]
        public async Task<ActionResult<FabricanteModel>> GetFabricanteById(int id)
        {
            FabricanteModel fabricante = await _fabricanteRepositorio.GetById(id);
            if (fabricante == null)
            {
                return NotFound();
            }
            return Ok(fabricante);
        }

        [HttpPost("CreateFabricante")]
        public async Task<ActionResult<FabricanteModel>> InsertFabricante([FromBody] FabricanteModel fabricanteModel)
        {
            FabricanteModel fabricante = await _fabricanteRepositorio.InsertFabricante(fabricanteModel);
            return CreatedAtAction(nameof(GetFabricanteById), new { id = fabricante.FabricanteId }, fabricante);
        }

        [HttpPut("UpdateFabricante/{id:int}")]
        public async Task<ActionResult<FabricanteModel>> UpdateFabricante(int id, [FromBody] FabricanteModel fabricanteModel)
        {
            fabricanteModel.FabricanteId = id;
            FabricanteModel fabricante = await _fabricanteRepositorio.UpdateFabricante(fabricanteModel, id);
            return Ok(fabricante);
        }

        [HttpDelete("DeleteFabricante/{id:int}")]
        public async Task<ActionResult> DeleteFabricante(int id)
        {
            bool deleted = await _fabricanteRepositorio.DeleteFabricante(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
