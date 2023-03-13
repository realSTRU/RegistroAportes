using RegistroAportes.Shared.Models;
using System.Linq.Expressions;

namespace RegistroAportes.Server.Services.PersonaServices
{
    public class PersonaService : IPersonaService
    {
        private readonly Context _context;

        public PersonaService(Context context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<Persona>> AddPersona(Persona persona)
        {
            var response = new ServiceResponse<Persona>();

            try
            {
                if(_context.Personas != null)
                {
                    _context.Personas.Add(persona);
                    await _context.SaveChangesAsync();
                    response.Data = persona;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Error al insertar la persona {persona.PersonaId}";
                }

                

            }catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

            
        }

        public async Task<ServiceResponse<Persona>> DeletePersona(int id)
        {
            var response = new ServiceResponse<Persona>();

            try
            {
                if(_context.Personas != null)
                {
                    var persona = await _context.Personas.FindAsync(id);
                    
                    if(persona != null) 
                    {
                        _context.Personas.Remove(persona);
                        await _context.SaveChangesAsync();
                        response.Data = persona;
                        
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = $"Error al eliminar, Persona con el Id:{id} no encontrada";
                    }
                }

            }
            catch (Exception ex) 
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Persona>> GetPersona(int id)
        {
            var response = new ServiceResponse<Persona>();
            

            try
            {
                if(_context.Personas != null)
                {
                    var persona =  await _context.Personas.FindAsync(id);
                    
                    if(persona == null)
                    {
                        response.Success = false;
                        response.Message = $"Persona no encontrada en el Id:{id}, Error en busqueda";
                    }
                    else
                    {
                        response.Data = persona;
                    }
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<ServiceResponse<List<Persona>>> GetPersonas()
        {

            var response = new ServiceResponse<List<Persona>>();

            try
            {
                if(_context.Personas != null)
                {
                    response = new ServiceResponse<List<Persona>>()
                    {
                        Data = await _context.Personas.ToListAsync()
                    };
                }
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;

        }

        public async Task<ServiceResponse<Persona>> ModifyPersona(Persona persona)
        {
            var response = new ServiceResponse<Persona>();

            try
            {
                if(_context.Personas != null)
                {
                    _context.Entry(persona).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    response.Data = persona;

                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }
    }
}
