using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Underbid.Shared.DTOs
{
    public class ChatDTO
    {
        public long ChatId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El Campo publicacion id es obligatorio.")]
        public long PublicacionId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El Campo usuario creador es obligatorio.")]
        public long UsuarioCreador { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "El Campo usuario generador es obligatorio.")]
        public long UsuarioGenerador { get; set; }

        public virtual PublicacioneDTO? Publicacion { get; set; }

        public virtual UsuarioDTO? UsuarioCreadorNavigation { get; set; }

        public virtual UsuarioDTO? UsuarioGeneradorNavigation { get; set; }
    }
}
