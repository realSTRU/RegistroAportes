using Microsoft.AspNetCore.ResponseCompression;
using RegistroAportes.Shared.Models;

namespace RegistroAportes.Server.Services.TipoAporteServices
{
    public class TipoAporteService : ITipoAporteService
    {

        private readonly Context _context;

        public TipoAporteService( Context context)
        {
                this._context = context;
        }


        public async Task<ServiceResponse<TipoAporte>> AddTipoAporte(TipoAporte tipo)
        {
            var response = new ServiceResponse<TipoAporte>();

            try
            {
               if(_context.TiposAportes != null)
               {
                    _context.TiposAportes.Add(tipo);
                    await _context.SaveChangesAsync();
                    response.Data = tipo;
               }
               else
               {
                    response.Success = false;
                    response.Message = "Error al guardar TipoAporte";
               }
            }
            catch (Exception ex) 
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<TipoAporte>> DeleteTipoAporte(int id)
        {
            var response = new ServiceResponse<TipoAporte>();
            
            try
            {
                if(_context.TiposAportes != null)
                {
                    var tipo = await _context.TiposAportes.FindAsync(id);

                    if (tipo != null)
                    {
                        _context.TiposAportes.Remove(tipo);
                        await _context.SaveChangesAsync();

                        response.Data = tipo;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Errores al eliminar en los servicios de TipoAporte";
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

        public async Task<ServiceResponse<TipoAporte>> GetTipoAporte(int id)
        {
            var response = new ServiceResponse<TipoAporte>();

            try 
            {
                if(_context.TiposAportes != null)
                {
                    var tipo = await _context.TiposAportes.FindAsync(id);

                    if (tipo != null)
                    {
                        response.Data = tipo;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = $"TipoAporte no encontrado en el Id:{id}";
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

        public async Task<ServiceResponse<List<TipoAporte>>> GetTipoAportes()
        {
            var response = new ServiceResponse<List<TipoAporte>>();

            try
            {
                if(_context.TiposAportes != null)
                {
                    response = new ServiceResponse<List<TipoAporte>>()
                    {
                        Data = await _context.TiposAportes.ToListAsync()
                    };
                }


            }catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

            
        }

        public async Task<ServiceResponse<TipoAporte>> ModifyTipoAporte(TipoAporte tipo)
        {
            var response = new ServiceResponse<TipoAporte>();

            try
            {
                if(_context.TiposAportes != null)
                {
                    _context.Entry(tipo).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    response.Data = tipo;
                }
               
            }
            catch (Exception ex) 
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
