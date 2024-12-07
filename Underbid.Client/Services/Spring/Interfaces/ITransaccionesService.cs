using Underbid.Shared.DTOs.Spring;

namespace Underbid.Client.Services.Spring.Interfaces
{
    public interface ITransaccionesService
    {
        Task<List<TransaccionDTO>> MostrarTransacciones();

        Task<TransaccionDTO> BuscarTransaccion(long id);

        Task<bool> CrearTransaccion(TransaccionDTO transaccion);
    }
}
