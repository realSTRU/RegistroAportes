using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace RegistroAportes.Client.Services.PersonaServices
{
    public class PersonaService : IPersonaService
    {
        private readonly HttpClient _http;

        public PersonaService(HttpClient http)
        {
            _http = http;
        }

        public List<Persona> ListPersona { get; set; } = new List<Persona>();


        public async Task<ServiceResponse<string>> Delete(int Id)
        {
            var response = await _http.DeleteAsync($"api/Persona/{Id}");
            response.EnsureSuccessStatusCode();

            var result =  await response.Content.ReadAsStringAsync();

            return new ServiceResponse<string> { Success = true , Data = result };
        }

        public async Task<Persona> Find(int Id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Persona>>($"api/Persona/{Id}");

            return result.Data;

        }

        public async Task GetList()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Persona>>>($"api/Persona");
            
            if(result != null && result.Data != null)
            {
                ListPersona = result.Data;
            }
        }

        public Task<ServiceResponse<Persona>> Save(Persona persona)
        {
            if (persona.PersonaId == 0)
            {
                return Insert(persona);
            }
            else
            {
                return Modify(persona);
            }
        }

        public async Task<ServiceResponse<Persona>> Insert (Persona persona)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Persona", persona);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Persona>();
                return new ServiceResponse<Persona> { Success = true, Data = result};
            }
            catch (Exception ex) 
            {
                return new ServiceResponse<Persona> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<Persona>> Modify (Persona persona)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/Persona" , persona);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Persona>();
                return new ServiceResponse<Persona> { Success = true, Data = result };
            }
            catch(Exception ex) 
            {
                return new ServiceResponse<Persona> { Success = false, Message = ex.Message };
            }
        }
    }
    
}
