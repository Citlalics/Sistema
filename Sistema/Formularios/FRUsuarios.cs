using Sistema.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Sistema.Formularios
{
    public partial class FRUsuarios : Form
    {
        public FRUsuarios()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
       private void cargarroles()
        {
            DataSet ds = new DataSet();
            Clases.Croles r = new Clases.Croles();
            Clases.Cconexion c = new Clases.Cconexion(r.ConsultaGeneral());
            ds = c.consultar();
            cmdrol.DataSource = ds.Tables[0];
            //cmbRoles.DisplayMember = ds.Tables[0].Columns[]
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bDPIZZAHOUSEDataSet1.USUARIOS' Puede moverla o quitarla según sea necesario.
            this.uSUARIOSTableAdapter1.Fill(this.bDPIZZAHOUSEDataSet1.USUARIOS);
            // TODO: esta línea de código carga datos en la tabla 'bDPIZZAHOUSEDataSet.USUARIOS' Puede moverla o quitarla según sea necesario.
            this.uSUARIOSTableAdapter.Fill(this.bDPIZZAHOUSEDataSet.USUARIOS);
            cargarroles();
         cargarfolio();

        }
        Clases.Cconexion c;
        Clases.Usuario B;

        void cargarfolio()
        {
            B = new Clases.Usuario();
            DataSet ds = new DataSet();
            c = new Clases.Cconexion(B.CONSULTARI());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                txtusu.Text = ds.Tables["Tabla"].Rows[0]["IDUSUARIO"].ToString();
                txtnombre.Text = ds.Tables["Tabla"].Rows[0]["NOMBRE"].ToString();
                txtcontra.Text = ds.Tables["Tabla"].Rows[0]["CONTRASEÑA"].ToString();
                cmdrol.SelectedValue = ds.Tables["Tabla"].Rows[0]["IDROL"].ToString();
            }
        }



        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdrol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripGuardar_Click(object sender, EventArgs e)
        {
            Graba();
        }
        Clases.Usuario g;
        private void Graba()
        {
            //Valida que no este vacía ninguna caja de texto
            if (string.IsNullOrEmpty(txtusu.Text) || string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtcontra.Text))
            {
                MessageBox.Show("Debe completar la información");
                return;
            }

            Clases.Usuario B = new Clases.Usuario(txtnombre.Text);
            DataSet ds = new DataSet();
            c = new Clases.Cconexion(B.CONSULTARI());
            ds = c.consultar();
            g = new Clases.Usuario(txtcontra.Text, txtnombre.Text);

            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new Clases.Cconexion(g.modificar());
            else
                c = new Clases.Cconexion(g.GRABAR());
            MessageBox.Show(c.Ejecutar());
        }

        private void toolStripBuscar_Click(object sender, EventArgs e)
        {
            busca();
        }
        private void busca()
        {
            try
            {
                g = new Clases.Usuario();
                Clases.Cconexion con = new Clases.Cconexion();
                if (con.Execute(g.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        txtnombre.Text = con.FieldValue;
                        consultar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        private void consultar()
        {
            if (!(txtnombre.Text == ""))
            {
                try
                {
                    B = new Clases.Usuario(txtnombre.Text);
                    DataSet ds = new DataSet();
                    c = new Clases.Cconexion(B.CONSULTARI());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        txtusu.Text = ds.Tables["Tabla"].Rows[0]["IDUSUARIO"].ToString();
                        txtnombre.Text = ds.Tables["Tabla"].Rows[0]["NOMBRE"].ToString();
                        txtcontra.Text = ds.Tables["Tabla"].Rows[0]["CONTRASEÑA"].ToString();
                        cmdrol.SelectedValue = ds.Tables["Tabla"].Rows[0]["IDROL"].ToString();

                        /* TXTCHO_MODELO.Text = ds.Tables["Tabla"].Rows[0]["CHO_MODELO"].ToString();
                         TXTCHO_TELEFONO.Text = ds.Tables["Tabla"].Rows[0]["CHO_TELEFONO"].ToString();
                         TXTCHO_COLOR.Text = ds.Tables["Tabla"].Rows[0]["CHO_COLOR"].ToString();*/
                        // TXTLOT_LOTE.Select(TXTLOT_LOTE.Text.Length, 0);

                    }
                    else

                        MessageBox.Show("No Existe este dato");
                    txtnombre.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }

            }
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            txtusu.Clear();
            txtnombre.Clear();
            txtcontra.Clear();
        }

        private void toolStripSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
