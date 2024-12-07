using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underbid.Shared.DTOs
{
    public class UsuarioDTO
    {
        public long UsuarioId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Documento { get; set; } = null!;

        public int KeycloakId { get; set; }

        public string TipoUsuario { get; set; } = null!;

        public string? Perfil { get; set; }
    }
}
