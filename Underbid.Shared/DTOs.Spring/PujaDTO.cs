using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underbid.Shared.DTOs.Spring
{
    public class PujaDTO
    {
        public long pujaId { get; set; }

        public long publicacionId { get; set; }

        public long usuarioId { get; set; }

        public double montoOfertado { get; set; }

        public DateTime fechaPuja { get; set; }

        public string estado { get; set; } = string.Empty;
    }
}
