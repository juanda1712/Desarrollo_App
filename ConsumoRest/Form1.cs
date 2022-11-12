using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumoRest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {

            string url = "http://www.contapp.somee.com/api/Contacto/Detalle?id=5";
            ResponseRest resMsj = new ResponseRest();

            resMsj = await Service.GetService(url,HttpMethod.Get );


            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Telefono");

            DataRow row = dt.NewRow();
            row["Nombre"] = resMsj.Data.nombre;
            row["Telefono"] = resMsj.Data.telefono;
            dt.Rows.Add(row);

            dataGridView1.DataSource = dt;


            MessageBox.Show(resMsj.StatusCode);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            string url = "http://www.contapp.somee.com/api/Contacto/Guardar";
            ResponseRest resMsj = new ResponseRest();
            Response Contact = new Response();
            Contact.idContacto = 0;
            Contact.idTipo = int.Parse(txtTipo.Text);
            Contact.nombre = txtNombre.Text;
            Contact.telefono = txtTel.Text;



            resMsj = await Service.PostService<Response>(url, HttpMethod.Post, Contact);
            MessageBox.Show(resMsj.StatusCode);

        }
    }
}
