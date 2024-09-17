using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;

        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        [HttpGet("GetAllFornecedores")]
        public async Task<ActionResult<List<FornecedorModel>>> GetAllFornecedores()
        {
            List<FornecedorModel> fornecedores = await _fornecedorRepositorio.GetAll();
            return Ok(fornecedores);
        }

        [HttpGet("GetFornecedorById/{id}")]
        public async Task<ActionResult<FornecedorModel>> GetFornecedorById(int id)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.GetById(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost("CreateFornecedor")]
        public async Task<ActionResult<FornecedorModel>> InsertFornecedor([FromBody] FornecedorModel fornecedorModel)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorio.InsertFornecedor(fornecedorModel);
            return CreatedAtAction(nameof(GetFornecedorById), new { id = fornecedor.FornecedorId }, fornecedor);
        }

        [HttpPut("UpdateFornecedor/{id:int}")]
        public async Task<ActionResult<FornecedorModel>> UpdateFornecedor(int id, [FromBody] FornecedorModel fornecedorModel)
        {
            fornecedorModel.FornecedorId = id;
            FornecedorModel fornecedor = await _fornecedorRepositorio.UpdateFornecedor(fornecedorModel, id);
            return Ok(fornecedor);
        }

        [HttpDelete("DeleteFornecedor/{id:int}")]
        public async Task<ActionResult> DeleteFornecedor(int id)
        {
            bool deleted = await _fornecedorRepositorio.DeleteFornecedor(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
