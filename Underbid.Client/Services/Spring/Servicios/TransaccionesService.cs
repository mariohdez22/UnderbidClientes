using System.Net.Http.Json;
using Underbid.Client.Services.Spring.Interfaces;
using Underbid.Shared.DTOs.Spring;

namespace Underbid.Client.Services.Spring.Servicios
{
    public class TransaccionesService : ITransaccionesService
    {
        private readonly HttpClient _httpClient;

        public TransaccionesService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiSpring");
        }

        public async Task<List<TransaccionDTO>> MostrarTransacciones()
        {
            var resultado = await _httpClient.GetFromJsonAsync<List<TransaccionDTO>>("api/transacciones");

            if (resultado != null)
            {
                List<TransaccionDTO> lista = resultado;
                return lista;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<TransaccionDTO> BuscarTransaccion(long id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<TransaccionDTO>($"api/transacciones/{id}");

            if (resultado != null)
            {
                TransaccionDTO transaccion = resultado;

                return transaccion;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<bool> CrearTransaccion(TransaccionDTO transaccion)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/transacciones", transaccion);
            var respuesta = await resultado.Content.ReadFromJsonAsync<bool>();

            if (respuesta == true)
            {
                return respuesta;
            }
            else
            {
                throw new Exception();
            }
        }

    }
}
