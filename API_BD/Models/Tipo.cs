using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_BD.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Contactos = new HashSet<Contacto>();
        }
        [JsonIgnore]
        public int IdTipo { get; set; }
        public string? Descripcion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Contacto> Contactos { get; set; }
    }
}
