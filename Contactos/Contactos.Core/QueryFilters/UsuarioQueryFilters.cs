using System;
using System.Collections.Generic;
using System.Text;

namespace Contactos.Core.QueryFilters
{
    public class UsuarioQueryFilters
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public int? Rol { get; set; }
        public int? Estatus { get; set; }
    }
}
