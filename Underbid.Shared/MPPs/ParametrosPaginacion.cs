﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underbid.Shared.MPPs
{
    public class ParametrosPaginacion
    {
        public int NumeroPagina { get; set; }

        public int TamañoPagina { get; set; }

        public string? Orden { get; set; }

        public string? Buscar { get; set; }

    }
}
