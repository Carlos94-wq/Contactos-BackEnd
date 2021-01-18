using System;
using System.Collections.Generic;
using System.Text;

namespace Contactos.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int IdEstatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FeechaBaja { get; set; }
    }
}
