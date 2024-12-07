using Underbid.Shared.DTOs;
using Underbid.Shared.MPPs;

namespace Underbid.Client.Services.NET.Interfaces
{
    public interface IPublicacionesService
    {
        Task<ApiResponse<List<PublicacioneDTO>>> MostrarPublicaciones(ParametrosPaginacion pp);

        Task<ApiResponse<List<PublicacioneDTO>>> MostrarPubliPorId(ParametrosPaginacion pp, long idUsuario);

        Task<PublicacioneDTO> BuscarPublicacion(long id);

        Task<string> CrearPublicacion(PublicacioneDTO publicacion);

        Task<string> EditarPublicacion(PublicacioneDTO publicacion, long id);

        Task<string> EliminarPublicacion(long id);
    }
}
