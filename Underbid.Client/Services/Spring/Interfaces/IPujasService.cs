using Underbid.Shared.DTOs.Spring;
using Underbid.Shared.MPPs;

namespace Underbid.Client.Services.Spring.Interfaces
{
    public interface IPujasService
    {

        Task<List<PujaDTO>> MostrarPujas();

        Task<PujaDTO> BuscarPuja(long id);

        Task<List<PujaDTO>> BuscarPujasPorPublicacion(long idPubli);

        Task<bool> CrearPuja(PujaDTO puja);

    }
}
