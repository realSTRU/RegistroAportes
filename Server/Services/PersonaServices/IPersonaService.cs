using RegistroAportes.Shared.Models;

namespace RegistroAportes.Server.Services.PersonaServices
{
    public interface IPersonaService
    {
        Task<ServiceResponse<List<Persona>>> GetPersonas();

        Task<ServiceResponse<Persona>> GetPersona(int id);

        Task<ServiceResponse<Persona>> AddPersona(Persona persona);

        Task<ServiceResponse<Persona>> ModifyPersona(Persona persona);

        Task<ServiceResponse<Persona>> DeletePersona(int id);
    }
}
