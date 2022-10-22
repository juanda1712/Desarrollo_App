using System;
using System.Collections.Generic;

namespace API_BD.Models
{
    public partial class Usuario
    {
        public int Idusuario { get; set; }
        public string? Nombre { get; set; }
        public string? Contraseña { get; set; }
        public string? Perfil { get; set; }
    }
}
