using System.Net;
using System.Net.Http.Json;
using Underbid.Client.Services.NET.Interfaces;
using Underbid.Shared.DTOs;
using Underbid.Shared.MPPs;

namespace Underbid.Client.Services.NET.Servicios
{
    public class MensajesService : IMensajesService
    {

        private readonly HttpClient _httpClient;

        public MensajesService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiSiget");
        }

        public async Task<ApiResponse<List<MensajeDTO>>> MostrarMensajes(ParametrosPaginacion pp)
        {
            string url = $"api/Mensajes/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _httpClient.GetFromJsonAsync<ApiResponse<List<MensajeDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<MensajeDTO> BuscarMensaje(long id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<ApiResponse<MensajeDTO>>($"api/Mensajes/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                MensajeDTO publicacion = resultado.Resultado;

                return publicacion;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> CrearMensaje(MensajeDTO mensaje)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/Mensajes/Agregar", mensaje);
            var respuesta = await resultado.Content.ReadFromJsonAsync<ApiResponse<string>>();

            if (respuesta!.CodigoEstado == HttpStatusCode.Created && respuesta!.EsExitoso == true)
            {
                return respuesta.Resultado;
            }
            else
            {
                throw new Exception(respuesta.MensajeError);
            }
        }

        public async Task<string> EditarMensaje(MensajeDTO mensaje, long id)
        {
            var resultado = await _httpClient.PutAsJsonAsync($"api/Mensajes/Editar/{id}", mensaje);
            var respuesta = await resultado.Content.ReadFromJsonAsync<ApiResponse<string>>();

            if (respuesta!.CodigoEstado == HttpStatusCode.NoContent && respuesta!.EsExitoso == true)
            {
                return respuesta.Resultado;
            }
            else
            {
                throw new Exception(respuesta.MensajeError);
            }
        }

        public async Task<string> EliminarMensaje(long id)
        {
            var resultado = await _httpClient.DeleteAsync($"api/Mensajes/Eliminar/{id}");
            var respuesta = await resultado.Content.ReadFromJsonAsync<ApiResponse<string>>();

            if (respuesta!.CodigoEstado == HttpStatusCode.NoContent && respuesta!.EsExitoso == true)
            {
                return respuesta.Resultado;
            }
            else
            {
                throw new Exception(respuesta.MensajeError);
            }
        }

    }
}
