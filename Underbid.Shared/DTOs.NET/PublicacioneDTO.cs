using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underbid.Shared.DTOs
{
    public class PublicacioneDTO
    {
        public long PublicacionId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El Campo usuario id es obligatorio.")]
        public long UsuarioId { get; set; }

        public string Titulo { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string? Tecnologias { get; set; }

        public string? PerfilRequerido { get; set; }

        public decimal PrecioInicial { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public string? Estado { get; set; }

        public virtual UsuarioDTO? Usuario { get; set; }
    }
}
