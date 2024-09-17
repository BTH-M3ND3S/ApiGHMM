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
    public class SetorController : ControllerBase
    {
        private readonly ISetorRepositorio _setorRepositorio;

        public SetorController(ISetorRepositorio setorRepositorio)
        {
            _setorRepositorio = setorRepositorio;
        }

        [HttpGet("GetAllSetores")]
        public async Task<ActionResult<List<SetorModel>>> GetAllSetores()
        {
            List<SetorModel> setores = await _setorRepositorio.GetAll();
            return Ok(setores);
        }

        [HttpGet("GetSetorById/{id}")]
        public async Task<ActionResult<SetorModel>> GetSetorById(int id)
        {
            SetorModel setor = await _setorRepositorio.GetById(id);
            if (setor == null)
            {
                return NotFound();
            }
            return Ok(setor);
        }

        [HttpPost("CreateSetor")]
        public async Task<ActionResult<SetorModel>> InsertSetor([FromBody] SetorModel setorModel)
        {
            SetorModel setor = await _setorRepositorio.InsertSetor(setorModel);
            return CreatedAtAction(nameof(GetSetorById), new { id = setor.SetorId }, setor);
        }

        [HttpPut("UpdateSetor/{id:int}")]
        public async Task<ActionResult<SetorModel>> UpdateSetor(int id, [FromBody] SetorModel setorModel)
        {
            setorModel.SetorId = id;
            SetorModel setor = await _setorRepositorio.UpdateSetor(setorModel, id);
            return Ok(setor);
        }

        [HttpDelete("DeleteSetor/{id:int}")]
        public async Task<ActionResult> DeleteSetor(int id)
        {
            bool deleted = await _setorRepositorio.DeleteSetor(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
