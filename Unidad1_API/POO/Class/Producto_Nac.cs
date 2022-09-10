using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad1_API.POO.Class
{
    internal class Producto_Nac : Producto
    {

        private string impuestos; 


        public string obtener_Ciudad()
        {
            return "Pereira";
        }

        public override string consulta_producto(int p_id)
        {
            return "producto  Nacional: ";
        }



    }
}
