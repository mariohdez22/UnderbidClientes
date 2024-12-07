using System.Net.Http.Json;
using Underbid.Client.Services.NET.Interfaces;
using Underbid.Shared.DTOs;
using Underbid.Shared.MPPs;

namespace Underbid.Client.Services.NET.Servicios
{
    public class UsuariosService : IUsuariosService
    {
        private readonly HttpClient _httpClient;

        public UsuariosService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiNet");
        }

        public async Task<List<UsuarioDTO>> MostrarUsuarios()
        {
            var resultado = await _httpClient.GetFromJsonAsync<ApiResponse<List<UsuarioDTO>>>("api/Usuarios/Consulta");

            if (resultado!.EsExitoso == true)
            {
                List<UsuarioDTO> lista = resultado.Resultado;
                return lista;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }
    }
}
