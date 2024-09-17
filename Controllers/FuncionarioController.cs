using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionariosRepositorio _funcionariosRepositorio;

        public FuncionarioController(IFuncionariosRepositorio funcionariosRepositorio)
        {
            _funcionariosRepositorio = funcionariosRepositorio;
        }

        [HttpGet("GetAllFuncionarios")]
        public async Task<ActionResult<List<FuncionarioModel>>> GetAllFuncionarios()
        {
            List<FuncionarioModel> funcionarios = await _funcionariosRepositorio.GetAll();
            return Ok(funcionarios);
        }

        [HttpGet("GetFuncionarioById/{id}")]
        public async Task<ActionResult<FuncionarioModel>> GetFuncionarioById(int id)
        {
            FuncionarioModel funcionario = await _funcionariosRepositorio.GetById(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpPost("CreateFuncionario")]
        public async Task<ActionResult<FuncionarioModel>> InsertFuncionario([FromBody] FuncionarioModel funcionarioModel)
        {
            FuncionarioModel funcionario = await _funcionariosRepositorio.InsertFuncionario(funcionarioModel);
            return CreatedAtAction(nameof(GetFuncionarioById), new { id = funcionario.FuncionarioId }, funcionario);
        }

        [HttpPut("UpdateFuncionario/{id:int}")]
        public async Task<ActionResult<FuncionarioModel>> UpdateFuncionario(int id, [FromBody] FuncionarioModel funcionarioModel)
        {
            funcionarioModel.FuncionarioId = id;
            FuncionarioModel funcionario = await _funcionariosRepositorio.UpdateFuncionario(funcionarioModel, id);
            return Ok(funcionario);
        }

        [HttpDelete("DeleteFuncionario/{id:int}")]
        public async Task<ActionResult> DeleteFuncionario(int id)
        {
            bool deleted = await _funcionariosRepositorio.DeleteFuncionario(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
