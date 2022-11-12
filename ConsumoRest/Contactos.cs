using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoRest
{
    public class Contactos
    {
        public string mensaje { get; set; }
        public Response response { get; set; }
    }
        public class Response
        {
            public int idContacto { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public string telefono { get; set; }
            public int idTipo { get; set; }
        
        }

     



    
}
