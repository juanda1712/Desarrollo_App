using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unidad1_API.POO.Class
{
    internal class Producto : ProdMaster
    {
        /// <summary>
        /// Atributos 
        /// </summary>
        /// 
        private int id;
        private string nombre;
        private string detalle;
        private double valor;
        protected int peso;   
        private int _iva;
        private string tipo_iva;

        public int Iva
        {
            get { return _iva; }
            set {
                    if (value > 19)
                        MessageBox.Show("Valor no valido");
                    else if (value == 19)
                    {
                        tipo_iva = "Normal";
                        _iva = value;
                     }
                    else if (value == 5)
                    { 
                        tipo_iva = "Aseo";
                        _iva = value;
                    }
                    else
                    {
                        tipo_iva = "NA";
                        _iva = value;
                    }            
                }
        }


        public Producto()
        {
            _iva = 19;    
        }

        public Producto(int p_id )
        {
            id = p_id;
        }
        public virtual string consulta_producto( int p_id)
        {
            return "producto : ";
        }

        public bool crear_producto( string p_nombre , string p_detalle )
        {
            this.nombre = p_nombre;
            this.detalle = p_detalle;
            return true;
        }

        public string consulta_producto()
        {
            throw new NotImplementedException();
        }

        public bool crear_producto()
        {
            throw new NotImplementedException();
        }

        public bool Mod_producto()
        {
            throw new NotImplementedException();
        }

        public void Generar_QR()
        {
            throw new NotImplementedException();
        }
    }
}
