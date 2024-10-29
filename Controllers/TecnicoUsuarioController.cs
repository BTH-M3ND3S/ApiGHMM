using ApiGHMM.Models;
using ApiGHMM.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGHMM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoUsuarioController : ControllerBase
    {
        private readonly ITecnicoUsuarioRepositorio _tecnicoUsuariosRepositorio;

        public TecnicoUsuarioController(ITecnicoUsuarioRepositorio tecnicoUsuariosRepositorio)
        {
            _tecnicoUsuariosRepositorio = tecnicoUsuariosRepositorio;
        }

        [HttpGet("GetAllTecnicoUsuarios")]
        public async Task<ActionResult<List<TecnicoUsuarioModel>>> GetAllTecnicoUsuario()
        {
            List<TecnicoUsuarioModel> tecnicoUsuarios = await _tecnicoUsuariosRepositorio.GetAll();
            return Ok(tecnicoUsuarios);
        }

        [HttpGet("GetTecnicoUsuarioById/{id}")]
        public async Task<ActionResult<TecnicoUsuarioModel>> GetTecnicoUsuarioById(int id)
        {
            TecnicoUsuarioModel tecnicoUsuario = await _tecnicoUsuariosRepositorio.GetById(id);
            if (tecnicoUsuario == null)
            {
                return NotFound();
            }
            return Ok(tecnicoUsuario);
        }

        [HttpPost("CreateTecnicoUsuario")]
        public async Task<ActionResult<TecnicoUsuarioModel>> InsertTecnicoUsuario([FromBody] TecnicoUsuarioModel tecnicoUsuarioModel)
        {
            TecnicoUsuarioModel tecnicoUsuario = await _tecnicoUsuariosRepositorio.InsertTecnicoUsuario(tecnicoUsuarioModel);
            return CreatedAtAction(nameof(GetTecnicoUsuarioById), new { id = tecnicoUsuario.TecnicoUsuarioId }, tecnicoUsuario);
        }

        [HttpPut("UpdateTecnicoUsuario/{id:int}")]
        public async Task<ActionResult<TecnicoUsuarioModel>> UpdateTecnicoUsuario(int id, [FromBody] TecnicoUsuarioModel tecnicoUsuarioModel)
        {
            tecnicoUsuarioModel.TecnicoUsuarioId = id;
            TecnicoUsuarioModel tecnicoUsuario = await _tecnicoUsuariosRepositorio.UpdateTecnicoUsuario(tecnicoUsuarioModel, id);
            return Ok(tecnicoUsuario);
        }

        [HttpDelete("DeleteTecnicoUsuario/{id:int}")]
        public async Task<ActionResult> DeleteTecnicoUsuario(int id)
        {
            bool deleted = await _tecnicoUsuariosRepositorio.DeleteTecnicoUsuario(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
