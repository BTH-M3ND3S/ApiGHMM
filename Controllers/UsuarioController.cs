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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuariosRepositorio;

        public UsuarioController(IUsuarioRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }

        [HttpGet("GetAllUsuarios")]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsuario()
        {
            List<UsuarioModel> usuarios = await _usuariosRepositorio.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("GetUsuarioById/{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioById(int id)
        {
            UsuarioModel usuario = await _usuariosRepositorio.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login([FromBody] UsuarioModel usuarioModel)
        {
            var usuario = await _usuariosRepositorio.Login(usuarioModel.UsuarioEmail, usuarioModel.UsuarioCpf, usuarioModel.UsuarioSenha);
            return Ok(usuario);
        }

        [HttpPost("CreateUsuario")]
        public async Task<ActionResult<UsuarioModel>> InsertUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuariosRepositorio.InsertUsuario(usuarioModel);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut("UpdateUsuario/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> UpdateUsuario(int id, [FromBody] UsuarioModel usuarioModel)
        {
            usuarioModel.UsuarioId = id;
            UsuarioModel usuario = await _usuariosRepositorio.UpdateUsuario(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("DeleteUsuario/{id:int}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            bool deleted = await _usuariosRepositorio.DeleteUsuario(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
