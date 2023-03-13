using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RegistroAportes.Shared.Models;

namespace RegistroAportes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAporteController : ControllerBase
    {
        private readonly ITipoAporteService _tipoAporteService;

        public TipoAporteController(ITipoAporteService tipoAporteService)
        {

            _tipoAporteService = tipoAporteService;


        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TipoAporte>>>> GetListTipoAportes()
        {
            var result = await _tipoAporteService.GetTipoAportes();

            return Ok(result);
        }

        [HttpGet("{TipoAporteId}")]
        public async Task<ActionResult<ServiceResponse<TipoAporte>>> GetTipoAporteById(int TipoAporteId)
        {
            var result = await _tipoAporteService.GetTipoAporte(TipoAporteId);

            if(result!= null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TipoAporte>>> InsertTipoAporte(TipoAporte tipoAporte)
        {
            var result = await _tipoAporteService.AddTipoAporte(tipoAporte);
            
            if(result.Success != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TipoAporte>>> ModifyTipoAporte(TipoAporte tipoAporte)
        {
            var result = await _tipoAporteService.ModifyTipoAporte(tipoAporte);

            if(result.Success != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        
        [HttpDelete("{TipoAporteId}")]
        public async Task<ActionResult<ServiceResponse<TipoAporte>>> DeleteTipoAporte(int TipoAporteId)
        {
            var result = await _tipoAporteService.DeleteTipoAporte(TipoAporteId);

            if(result.Success = false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
