using Underbid.Shared.DTOs;
using Underbid.Shared.MPPs;

namespace Underbid.Client.Services.NET.Interfaces
{
    public interface IChatService
    {
        Task<ApiResponse<List<ChatDTO>>> MostrarChats(ParametrosPaginacion pp);

        Task<ChatDTO> BuscarChat(long id);

        Task<string> CrearChat(ChatDTO chat);

        Task<string> EditarChat(ChatDTO chat, long id);

        Task<string> EliminarChat(long id);
    }
}
