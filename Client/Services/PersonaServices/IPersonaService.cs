

namespace RegistroAportes.Client.Services.PersonaServices
{
    public interface IPersonaService
    {

        List<Persona> ListPersona { get; set; }

        Task<Persona> Find(int Id);
        Task<ServiceResponse<Persona>> Save(Persona persona);

        Task GetList();

        Task<ServiceResponse<string>> Delete(int Id);



    }
}
