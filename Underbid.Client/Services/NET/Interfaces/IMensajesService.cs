using Underbid.Client.Services.NET.Interfaces;
using Underbid.Shared.DTOs;
using Underbid.Shared.MPPs;

namespace Underbid.Client.Services.NET.Interfaces
{
    public interface IMensajesService
    {
        Task<ApiResponse<List<MensajeDTO>>> MostrarMensajes(ParametrosPaginacion pp);

        Task<MensajeDTO> BuscarMensaje(long id);

        Task<string> CrearMensaje(MensajeDTO mensaje);

        Task<string> EditarMensaje(MensajeDTO mensaje, long id);

        Task<string> EliminarMensaje(long id);
    }
}
