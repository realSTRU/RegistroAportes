using RegistroAportes.Shared.Models;



namespace RegistroAportes.Server.Services.TipoAporteServices
{
    public interface ITipoAporteService
    {
        Task<ServiceResponse<List<TipoAporte>>> GetTipoAportes();

        Task<ServiceResponse<TipoAporte>> GetTipoAporte(int id);

        Task<ServiceResponse<TipoAporte>> AddTipoAporte(TipoAporte tipo);

        Task<ServiceResponse<TipoAporte>> ModifyTipoAporte(TipoAporte tipo);

        Task<ServiceResponse<TipoAporte>> DeleteTipoAporte(int id);






    }
}
