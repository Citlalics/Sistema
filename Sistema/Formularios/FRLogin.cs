using Sistema.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class FRLogin : Form
    {
        public FRLogin()
        {
            InitializeComponent();
        }
        Clases.Cconexion c;
        Clases.Usuario cu;
        private void button2_Click(object sender, EventArgs e)
        {
            acceso();
        }
        private void acceso()
        {
            Clases.Usuario U = new Clases.Usuario(txtusuario.Text, txtcontra.Text);
            DataSet ds = new DataSet();
           //mandar llamar el metodo
            c = new Clases.Cconexion(U.CONSULTARI());
            ds = c.consultar();

            if (ds.Tables["tabla"].Rows.Count > 0)
            {
                FRMenú x = new FRMenú();
                x.Show(); this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectas", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtusuario.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
