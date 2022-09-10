using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unidad1_API.POO.Class;

namespace Unidad1_API.POO.Views
{
    public partial class Landing : Form
    {
        Producto OBProd = new Producto();
        Producto_Nac OBProd_Nac = new Producto_Nac();
        Factura OBFactura = new Factura();
        public Landing()
        {
            InitializeComponent();
        }

        private void Landing_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OBProd.Iva = 19;
            var iva = OBProd.Iva;
            if (OBProd.crear_producto("Galletas", "Ducales"))
            {
                MessageBox.Show("Producto creado exitosamente");
            }


            MessageBox.Show( OBProd.consulta_producto(10));

            OBProd_Nac.obtener_Ciudad();
            MessageBox.Show(OBProd_Nac.consulta_producto(10));
            OBProd_Nac.Iva = 5;

            OBFactura.Generar_factura(OBProd_Nac);

            MessageBox.Show(Sys.name_bd);
            Sys.Generar_log();



        }
        
    }
}
