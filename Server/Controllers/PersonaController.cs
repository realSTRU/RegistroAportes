using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroAportes.Server.Services.PersonaServices;
using RegistroAportes.Shared.Models;

namespace RegistroAportes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;   
        }

        [HttpGet("{PersonaId}")]
        public async Task<ActionResult<ServiceResponse<Persona>>> FindPersona(int PersonaId )
        {
            var result = await _personaService.GetPersona(PersonaId);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

            
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Persona>>> GetList()
        {
            var result = await _personaService.GetPersonas();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Persona>>> Insert(Persona persona)
        {
            var result = await _personaService.AddPersona(persona);

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
        public async Task<ActionResult<ServiceResponse<Persona>>> Modify(Persona persona)
        {
            var result = await _personaService.ModifyPersona(persona);
            if(result.Success != false )
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
       
        }


        [HttpDelete("{PersonaId}")]
        public async Task<ActionResult> Delete(int PersonaId)
        {
            var result = await _personaService.DeletePersona(PersonaId);
            if(result.Success != false)
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
