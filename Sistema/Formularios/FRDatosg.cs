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
    public partial class Datos_Generales : Form
    {
        public Datos_Generales()
        {
            InitializeComponent();
        }

        private void Datos_Generales_Load(object sender, EventArgs e)
        {
            cargarfolio();
        }

        Clases.Cconexion c;
        Clases.Cdatosg b ;
        void cargarfolio()
        {
            b = new Clases.Cdatosg();
            DataSet ds = new DataSet();
            c = new Clases.Cconexion(b.CONSULTARI());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                txtNomempre.Text = ds.Tables["Tabla"].Rows[0]["nom_empresa"].ToString();
                txtGerente.Text = ds.Tables["Tabla"].Rows[0]["gerente"].ToString();
                txtTelefono.Text = ds.Tables["Tabla"].Rows[0]["telefono"].ToString();
                txtDireccion.Text = ds.Tables["Tabla"].Rows[0]["direccion"].ToString();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Graba();
        }
        Clases.Cdatosg g;
        private void Graba()
        {
            
            if (string.IsNullOrEmpty(txtNomempre.Text) || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Debe completar la información");
                return;
            }

            Clases.Cdatosg B = new Clases.Cdatosg(txtNomempre.Text);
            DataSet ds = new DataSet();
            c = new Clases.Cconexion(B.CONSULTARI());
            ds = c.consultar();
            g = new Clases.Cdatosg(txtNomempre.Text, txtDireccion.Text, txtTelefono.Text, txtGerente.Text);

            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new Clases.Cconexion(g.modificar());
            else
                c = new Clases.Cconexion(g.GRABAR());
            MessageBox.Show(c.Ejecutar());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            busca();
        }
        private void busca()
        {
            try
            {
                g = new Clases.Cdatosg();
                Clases.Cconexion con = new Clases.Cconexion();
                if (con.Execute(g.Consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        txtNomempre.Text = con.FieldValue;
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
            if (!(txtNomempre.Text == ""))
            {
                try
                {
                    b = new Clases.Cdatosg(txtNomempre.Text);
                    DataSet ds = new DataSet();
                    c = new Clases.Cconexion(b.CONSULTARI());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        txtNomempre.Text = ds.Tables["Tabla"].Rows[0]["nom_empresa"].ToString();
                        txtDireccion.Text = ds.Tables["Tabla"].Rows[0]["direccion"].ToString();
                        txtTelefono.Text = ds.Tables["Tabla"].Rows[0]["telefono"].ToString();
                        txtGerente.Text = ds.Tables["Tabla"].Rows[0]["gerente"].ToString();

                        /* TXTCHO_MODELO.Text = ds.Tables["Tabla"].Rows[0]["CHO_MODELO"].ToString();
                         TXTCHO_TELEFONO.Text = ds.Tables["Tabla"].Rows[0]["CHO_TELEFONO"].ToString();
                         TXTCHO_COLOR.Text = ds.Tables["Tabla"].Rows[0]["CHO_COLOR"].ToString();*/
                        // TXTLOT_LOTE.Select(TXTLOT_LOTE.Text.Length, 0);

                    }
                    else

                        MessageBox.Show("No Existe este dato");
                    txtNomempre.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            txtNomempre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtGerente.Clear();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
  