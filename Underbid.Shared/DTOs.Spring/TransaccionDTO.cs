using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underbid.Shared.DTOs.Spring
{
    public class TransaccionDTO
    {
        public long transaccionId { get; set; }

        public long publicacionId { get; set; }

        public long pujaId { get; set; }

        public double montoTotal { get; set; }

        public double montoAnticipo { get; set; }

        public DateTime fechaTransaccion { get; set; }

        public string estado { get; set; } = string.Empty;
    }
}
