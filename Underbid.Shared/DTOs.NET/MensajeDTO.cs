using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underbid.Shared.DTOs
{
    public class MensajeDTO
    {
        public long MensajeId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El Campo chat es obligatorio.")]
        public long ChatId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El Campo usuario es obligatorio.")]
        public long UsuarioId { get; set; }

        public string Contenido { get; set; } = null!;

        public DateTime? FechaEnvio { get; set; }

        public virtual ChatDTO? Chat { get; set; }

        public virtual UsuarioDTO? Usuario { get; set; }
    }
}
