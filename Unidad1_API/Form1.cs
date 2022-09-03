using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unidad1_API.POO.Views;

namespace Unidad1_API
{

    public partial class Form1 : Form
    {
        string Pais = "Colombia";

        public Form1()
        {
            InitializeComponent();


        }

        public void Cargar_datos(string dt)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //string nombre = "Juan";
            //int num_1 = 10;
            //bool bl = true;
            //char ch;
            //decimal dec_1;
            //float fl;
            //double db = 50;
            //long lg;
            //object carro = new { llanta = "KENDA" };
            //Pais = "Peru";

            //lg = num_1;

          
            //var peso = carro;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Nombre = txtnombre.Text;
            int num1 , num2 , num3;
            double dec1;

            ///  Conversiones 

            //num1 = int.Parse(Nombre);
            //num1 = Convert.ToInt32(Nombre);

            //dec1 = double.Parse(Nombre);
            //dec1 = Convert.ToDouble(Nombre);
            num1 = 30;
            num2 = 10;

            // operaciones
            num3= num1 + num2;

            // Fun con String
            var substr = Nombre.Substring(0, 4);
            var mayus = Nombre.ToUpper();
            var minus = Nombre.ToLower();
            var quitar_esp = Nombre.Trim();
            var tamaño = Nombre.Length;

            // concatenar 
            string resultado = string.Concat(substr," - ",mayus," - " , tamaño," - ", minus );
            resultado = string.Format("Mi nombre es:{0} y en mayus es:{1}",Nombre,mayus);


            var Resulta_sum = suma(10 , 10);
            MessageBox.Show(Resulta_sum.ToString());
           

        }



        private void limpiar()
        {
            txtnombre.Text = "";
        }

        private int suma ( int p1 , int p2 , int p3 = 0)
        {
            int resultado = p1 + p2;
            return resultado;

        }

        //private double suma(double p1, double p2)
        //{
        //    double resultado = p1 + p2;
        //    return resultado;

        //}
        private int suma(string p1, string p2 )
        {
            int resultado = int.Parse(p1) + int.Parse(p2);
            return resultado;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = 0;
            string Nombre = txtnombre.Text;

            ///   ||  or   &&   and
            if (Nombre == "Juan" || Nombre == "Carlos")
            {
                num = 1;
            }
            else if(Nombre == "Pedro" && num == 0)
            {
                num = 2;
            }
            else 
            {
                num = 3;
            }

            if (num > 0)
            {
            }
            else if( num >= 0)
            {             
            }


            //// SWICHE
            ///

            string mes;
            string txtMes = txtnombre.Text;

            switch (txtMes)
            {

                case "1":
                    mes = "Enero";
                    break;

                case "2":
                    mes = "Febrero";
                    break ;

                default:
                    mes = "No disponible";
                    break;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            int cl = int.Parse(txtnombre.Text);

            //while(cl >= 0)
            //{
            //    MessageBox.Show(cl.ToString());
            //    cl--;                
            //}


            //do
            //{
            //    MessageBox.Show("Cedula");

            //}
            //while (cl >= 18);


            int total = 0;
            for (int i = 0; i <= cl; i++)
            {
                if ((i % 2) == 0 )
                {
                    total++;
                }
            }

            MessageBox.Show(String.Concat("Total de numero pares: " , total.ToString()));



        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] Num = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            Num[0] = 1;
            Num[1] = 5;
            Num[2] = 6;

            //for (int i = 0; i < Num.Length; i++)
            //{
            //    MessageBox.Show(Num[i].ToString());

            //}

            //Num = new int[20];

            //Array.Resize(ref Num, 20);   /// aumentando el tamaño del array

            /// matrices 
            /// 

            int[,] mt;
            mt = new int[2, 2] { { 1, 2 }, { 3, 4 } };



            /// Listas
            /// 

            //List<string> Nombres = new List<string>() { "Juan", "Carlos" };
            //Nombres.Add("David");
            //Nombres.Add("Ana");


            //Nombres.Remove("Carlos");
            //Nombres.RemoveAt(0);


            //string item = Nombres[0];

            //for (int i = 0; i < Nombres.Count; i++)
            //{
            //    MessageBox.Show(Nombres[i]);
            //}

            //foreach (string nm in Nombres)
            //{
            //    MessageBox.Show(item);
            //}



            ///Diccionario
            ///

            Dictionary<int, string> User = new Dictionary<int, string>();
            User.Add(1, "Juan");
            User.Add(2, "Ana");
            User.Add(3, "Jose");

            User[1] = "Carlos";

            User.Remove(1);
            User.Clear();
            var usuario = User[2];


            foreach (var usr in User)
            {
                MessageBox.Show(usr.Value);
            }




    }

        private void button5_Click(object sender, EventArgs e)
        {
            string Nombre = txtnombre.Text;
            int num1;

            try
            {
                num1 = int.Parse(Nombre);
                if (num1 == 3)
                {
                    throw new Exception();              
                }

            }
            catch (FormatException ex1)
            {
                MessageBox.Show("Valor no valido, ingrese solo numeros");
            }
            catch (OverflowException ex2)
            {
                MessageBox.Show("Valor no valido, ingrese el campo nuevamente");
            }
            catch (Exception ex3)
            {
                MessageBox.Show("Valor no valido");
                // ROLLBACK
                // LOG
            }
            finally
            {
                txtnombre.Clear();            
            }










        }

        private void button6_Click(object sender, EventArgs e)
        {

            DataTable dt_User = new DataTable();

            dt_User.Columns.Add("ID");
            dt_User.Columns.Add("NOMBRE");
            dt_User.Columns.Add("APELLIDO");
            dt_User.Columns.Add("CIUDAD");

            dt_User.Rows.Add(); 
            dt_User.Rows.Add(new object[] { "10", txtnombre.Text });

            DataRow dr_user = dt_User.NewRow();
            dr_user["ID"] = "20";
            dr_user["NOMBRE"] = txtnombre.Text;
            dr_user["APELLIDO"] = "Lopez";
            dt_User.Rows.Add(dr_user);
                        
            //foreach (DataRow item in dt_User.Rows)
            //{
            //   txtdetalle.Text = item["NOMBRE"].ToString();
            //}

            //for (int i = 0; i < dt_User.Rows.Count -1; i++)
            //{
            //    txtdetalle.Text = dt_User.Rows[i]["NOMBRE"].ToString() ;               
            //}

            dt_User.Rows[1]["APELLIDO"] = "MORALES";
            txtdetalle.Text = dt_User.Rows[2]["NOMBRE"].ToString();

            DataSet  dsAPP1 = new DataSet();
            dsAPP1.Tables.Add(dt_User);
        

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Landing frm_poo = new Landing();
            frm_poo.Show();
            this.Hide();

        }
    }
}
