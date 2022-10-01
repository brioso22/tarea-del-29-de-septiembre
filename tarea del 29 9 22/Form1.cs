using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tarea_del_29_9_22
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNombre,"");
            txtAFP.Text = (Convert.ToDouble(txtSalario.Text) * 0.0625).ToString();
        }

        private void btnAFP_Click(object sender, EventArgs e)
        {
    
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Empleado.mdf;Integrated Security=True;Connect Timeout=30");
             conexion.Open();
            string nombre = txtNombre.Text;
            string dui = txtDUI.Text;
            string salario = txtSalario.Text;
            string afp = txtAFP.Text;
            string cadena = "insert into [Empleados] (Nombre, DUI, Salario, AFP) values ('" + nombre + "','" + dui + "','" + salario + "','" + afp + "')";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaron correctamente");

            conexion.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Empleado.mdf;Integrated Security=True;Connect Timeout=30");
            conexion.Open();
            string cod = textBox1.Text;
            string cadena = "select nombre,dui from Empleados where Id=" + cod;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                label5.Text= registro["Nombre"].ToString();
                label6.Text= registro["DUI"].ToString();
            }
            else
                MessageBox.Show("No existe un Empleado con el código ingresado");
            conexion.Close();


        }
    }
}
