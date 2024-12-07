using System.Net;
using System.Net.Http.Json;
using Underbid.Client.Services.NET.Interfaces;
using Underbid.Shared.DTOs;
using Underbid.Shared.MPPs;

namespace Underbid.Client.Services.NET.Servicios
{
    public class PublicacionesService : IPublicacionesService
    {
        private readonly HttpClient _httpClient;

        public PublicacionesService(IHttpClientFactory httpFactory)
        {
            _httpClient = httpFactory.CreateClient("ApiNet");
        }

        public async Task<ApiResponse<List<PublicacioneDTO>>> MostrarPublicaciones(ParametrosPaginacion pp)
        {
            string url = $"api/Publicaciones/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _httpClient.GetFromJsonAsync<ApiResponse<List<PublicacioneDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<ApiResponse<List<PublicacioneDTO>>> MostrarPubliPorId(ParametrosPaginacion pp, long idUsuario)
        {
            string url = $"api/Publicaciones/ConsultaUser/{idUsuario}?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&Orden={pp.Orden}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _httpClient.GetFromJsonAsync<ApiResponse<List<PublicacioneDTO>>>(url);

            if (resultado!.EsExitoso == true)
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<PublicacioneDTO> BuscarPublicacion(long id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<ApiResponse<PublicacioneDTO>>($"api/Publicaciones/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                PublicacioneDTO publicacion = resultado.Resultado;

                return publicacion;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> CrearPublicacion(PublicacioneDTO publicacion)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/Publicaciones/Agregar", publicacion);
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

        public async Task<string> EditarPublicacion(PublicacioneDTO publicacion, long id)
        {
            var resultado = await _httpClient.PutAsJsonAsync($"api/Publicaciones/Editar/{id}", publicacion);
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

        public async Task<string> EliminarPublicacion(long id)
        {
            var resultado = await _httpClient.DeleteAsync($"api/Publicaciones/Eliminar/{id}");
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
