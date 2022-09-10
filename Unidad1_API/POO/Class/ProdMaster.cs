using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad1_API.POO.Class
{
    interface ProdMaster
    {

        string consulta_producto();
        bool crear_producto ();
        bool Mod_producto();

        void Generar_QR();



    }
}
