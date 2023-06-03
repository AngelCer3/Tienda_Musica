using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_Musica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregar objFrm = new frmAgregar();
            objFrm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificar objFrm = new frmModificar();
            objFrm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminar objFrm = new frmEliminar();
            objFrm.Show();
        }
    }
}
