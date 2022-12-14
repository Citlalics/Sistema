using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Formularios
{
    public partial class FRMenú : Form
    {
        public FRMenú()
        {
            InitializeComponent();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRroles rol = new FRroles();
            this.Hide(); rol.Show(); 
        }

        private void FRMenú_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void datosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datos_Generales dg = new Datos_Generales();
            this.Hide();  dg.Show(); 
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRUsuarios usu = new FRUsuarios();
            this.Hide(); usu.Show();
        }

        private void datosGeneralesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Datos_Generales dg = new Datos_Generales();
            this.Hide(); dg.Show();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permisos dg = new Permisos();
            this.Hide(); dg.Show();
        }

        private void módulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRmodulos dg = new FRmodulos();
            this.Hide(); dg.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
