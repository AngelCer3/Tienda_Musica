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
    public partial class frmModificar : Form
    {
        public static string cadena = "Data Source=DESKTOP-NDFKCD6\\SQLEXPRESS;Initial Catalog=Musica;Integrated Security=True";
        SqlConnection conn = new SqlConnection(cadena);
        public frmModificar()
        {
            InitializeComponent();
        }
        

        private void frmModificar_Load(object sender, EventArgs e)
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string dato = dtgProductos.CurrentRow.Cells[0].Value.ToString();
            int id = Convert.ToInt32(dato);
            string query = "UPDATE t_productos SET Nombre_del_Producto = @Nombre_del_Producto , Tipo_del_Producto = @Tipo_del_Producto, Cantidad_del_Producto = @Cantidad_del_Producto Where id_producto = @ID";
            conn.Open();
            SqlCommand comando = new SqlCommand(query, conn);
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@Nombre_del_Producto", txtNombreProducto.Text);
            comando.Parameters.AddWithValue("@Tipo_del_Producto", txtTipoProducto.Text);
            comando.Parameters.AddWithValue("@Cantidad_del_Producto", txtCantidad.Text);
            comando.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Datos Actualizados Correctamente");
            //Limpiar los textbox
            txtNombreProducto.Clear();
            txtTipoProducto.Clear();
            txtCantidad.Clear();
            Crud();
        }
        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreProducto.Text = dtgProductos.CurrentRow.Cells[1].Value.ToString();
            txtTipoProducto.Text = dtgProductos.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Text = dtgProductos.CurrentRow.Cells[3].Value.ToString();
        }
        private void dtgProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreProducto.Text = dtgProductos.CurrentRow.Cells[1].Value.ToString();
            txtTipoProducto.Text = dtgProductos.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Text = dtgProductos.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
