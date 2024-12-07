using System.Net;
using System.Net.Http.Json;
using Underbid.Client.Services.NET.Interfaces;
using Underbid.Shared.DTOs;
using Underbid.Shared.MPPs;

namespace Underbid.Client.Services.NET.Servicios
{
    public class ChatService : IChatService
    {
        private readonly HttpClient _httpClient;

        public ChatService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiNet");
        }

        public async Task<ApiResponse<List<ChatDTO>>> MostrarChats(ParametrosPaginacion pp)
        {
            string url = $"api/Chat/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _httpClient.GetFromJsonAsync<ApiResponse<List<ChatDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<ChatDTO> BuscarChat(long id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<ApiResponse<ChatDTO>>($"api/Chat/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                ChatDTO publicacion = resultado.Resultado;

                return publicacion;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> CrearChat(ChatDTO chat)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/Chat/Agregar", chat);
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

        public async Task<string> EditarChat(ChatDTO chat, long id)
        {
            var resultado = await _httpClient.PutAsJsonAsync($"api/Chat/Editar/{id}", chat);
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

        public async Task<string> EliminarChat(long id)
        {
            var resultado = await _httpClient.DeleteAsync($"api/Chat/Eliminar/{id}");
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
