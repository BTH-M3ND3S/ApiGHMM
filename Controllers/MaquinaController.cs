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
    public class MaquinaController : ControllerBase
    {
        private readonly IMaquinaRepositorio _maquinaRepositorio;

        public MaquinaController(IMaquinaRepositorio maquinaRepositorio)
        {
            _maquinaRepositorio = maquinaRepositorio;
        }

        [HttpGet("GetAllMaquinas")]
        public async Task<ActionResult<List<MaquinaModel>>> GetAllMaquinas()
        {
            List<MaquinaModel> maquinas = await _maquinaRepositorio.GetAll();
            return Ok(maquinas);
        }

        [HttpGet("GetMaquinaById/{id}")]
        public async Task<ActionResult<MaquinaModel>> GetMaquinaById(int id)
        {
            MaquinaModel maquina = await _maquinaRepositorio.GetById(id);
            if (maquina == null)
            {
                return NotFound();
            }
            return Ok(maquina);
        }

        [HttpPost("CreateMaquina")]
        public async Task<ActionResult<MaquinaModel>> InsertMaquina([FromBody] MaquinaModel maquinaModel)
        {
            MaquinaModel maquina = await _maquinaRepositorio.InsertMaquina(maquinaModel);
            return CreatedAtAction(nameof(GetMaquinaById), new { id = maquina.MaquinaId }, maquina);
        }

        [HttpPut("UpdateMaquina/{id:int}")]
        public async Task<ActionResult<MaquinaModel>> UpdateMaquina(int id, [FromBody] MaquinaModel maquinaModel)
        {
            maquinaModel.MaquinaId = id;
            MaquinaModel maquina = await _maquinaRepositorio.UpdateMaquina(maquinaModel, id);
            return Ok(maquina);
        }

        [HttpDelete("DeleteMaquina/{id:int}")]
        public async Task<ActionResult> DeleteMaquina(int id)
        {
            bool deleted = await _maquinaRepositorio.DeleteMaquina(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
