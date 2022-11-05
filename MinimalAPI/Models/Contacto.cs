using System;
using System.Collections.Generic;

namespace MinimalAPI.Models
{
    public partial class Contacto
    {
        public int IdContacto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Telefono { get; set; }
        public int? IdTipo { get; set; }

        public virtual Tipo? ObjTipo { get; set; }
    }
}
