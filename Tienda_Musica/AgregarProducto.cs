using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tienda_Musica
{
    public partial class frmAgregar : Form
    {
        public static string cadena = "Data Source=DESKTOP-NDFKCD6\\SQLEXPRESS;Initial Catalog=Musica;Integrated Security=True";
        SqlConnection conn = new SqlConnection(cadena);


        public frmAgregar()
        {
            InitializeComponent();
        }
        private void frmAgregar_Load(object sender, EventArgs e)
        {
            Crud();
        }
        public void Crud()
        {
            string query = "SELECT * FROM t_productos";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            conn.Close();
            dtgProductos.DataSource = dt;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            string query = "Insert into t_productos (Nombre_del_Producto,Tipo_del_Producto,Cantidad_del_Producto) VALUES(@Nombre_del_Producto,@Tipo_del_Producto,@Cantidad_del_Producto)";
            conn.Open();
            SqlCommand comando = new SqlCommand(query, conn);
            comando.Parameters.AddWithValue("@Nombre_del_Producto",txtNombreProducto.Text);
            comando.Parameters.AddWithValue("@Tipo_del_Producto", txtTipoProducto.Text);
            comando.Parameters.AddWithValue("@Cantidad_del_Producto", txtCantidad.Text);
            comando.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Datos Agregados Correctamente");
            //Limpiar los textbox
            txtNombreProducto.Clear();
            txtTipoProducto.Clear();
            txtCantidad.Clear();
            Crud();
        }

        private void txtNombreProducto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
