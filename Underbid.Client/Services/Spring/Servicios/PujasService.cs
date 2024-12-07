using System.Net;
using System.Net.Http.Json;
using Underbid.Client.Services.Spring.Interfaces;
using Underbid.Shared.DTOs.Spring;
using Underbid.Shared.MPPs;

namespace Underbid.Client.Services.Spring.Servicios
{
    public class PujasService : IPujasService
    {
        private readonly HttpClient _httpClient;

        public PujasService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiSpring");
        }

        public async Task<List<PujaDTO>> MostrarPujas()
        {
            var resultado = await _httpClient.GetFromJsonAsync<List<PujaDTO>>("api/pujas");

            if (resultado != null)
            {
                List<PujaDTO> lista = resultado;
                return lista;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<PujaDTO> BuscarPuja(long id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<PujaDTO>($"api/pujas/{id}");

            if (resultado != null)
            {
                PujaDTO puja = resultado;

                return puja;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<PujaDTO>> BuscarPujasPorPublicacion(long idPubli)
        {
            var resultado = await _httpClient.GetFromJsonAsync<List<PujaDTO>>($"api/pujas/publicacion/{idPubli}");

            if (resultado != null)
            {
                List<PujaDTO> articulo = resultado;

                return articulo;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<bool> CrearPuja(PujaDTO puja)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/pujas", puja);
            return resultado.IsSuccessStatusCode;
        }

    }
}
