using Underbid.Shared.DTOs;

namespace Underbid.Client.Services.NET.Interfaces
{
    public interface IUsuariosService
    {
        Task<List<UsuarioDTO>> MostrarUsuarios();
    }
}
