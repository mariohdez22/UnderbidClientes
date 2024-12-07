using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Underbid.Shared.MPPs
{
    public class ApiResponse<T>
    {
        public HttpStatusCode CodigoEstado { get; set; }

        public bool EsExitoso { get; set; }

        public T Resultado { get; set; }

        public long TotalRegistros { get; set; }

        //---------------------------------------------------------[MANEJO DE ERRORES]

        public string MensajeError { get; set; }

        public List<string> MensajesError { get; set; }
    }
}
