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
    public partial class Permisos : Form
    {
        public Permisos()
        {
            InitializeComponent();
        }

        private void Permisos_Load(object sender, EventArgs e)
        {
            cargarfolio();
        }
        Clases.Cconexion c;
        Clases.Cpermisos B;
        void cargarfolio()
        {
            B = new Clases.Cpermisos();
            DataSet ds = new DataSet();
            c = new Clases.Cconexion(B.CONSULTARI());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                txtIdPer.Text = ds.Tables["Tabla"].Rows[0]["id"].ToString();
                txtId_rol.Text = ds.Tables["Tabla"].Rows[0]["id_rol"].ToString();
                txtId_modu.Text = ds.Tables["Tabla"].Rows[0]["id_modulo"].ToString();
                rbBuscar.Text = ds.Tables["Tabla"].Rows[0]["buscar"].ToString();
                rbGrabar.Text = ds.Tables["Tabla"].Rows[0]["grabar"].ToString();
                rbActualizar.Text = ds.Tables["Tabla"].Rows[0]["modificar"].ToString();
                rbBorrar.Text = ds.Tables["Tabla"].Rows[0]["eliminar"].ToString();
            }
        }

        private void rbBuscar_CheckedChanged(object sender, EventArgs e)
        {
            Busca();
        }
        Clases.Cpermisos g;

        private void Busca()
        {
            try
            {
                g = new Clases.Cpermisos();
                Clases.Cconexion con = new Clases.Cconexion();
                if (con.Execute(g.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        txtIdPer.Text = con.FieldValue;
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
            if (!(txtIdPer.Text == ""))
            {
                try
                {
                    B = new Clases.Cpermisos(Convert.ToInt32(txtIdPer.Text));
                    DataSet ds = new DataSet();
                    c = new Clases.Cconexion(B.CONSULTARI());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        txtIdPer.Text = ds.Tables["Tabla"].Rows[0]["id"].ToString();
                        txtId_rol.Text = ds.Tables["Tabla"].Rows[0]["id_rol"].ToString();
                        txtId_modu.Text = ds.Tables["Tabla"].Rows[0]["id_modulo"].ToString();
                        rbBuscar.Text = ds.Tables["Tabla"].Rows[0]["buscar"].ToString();
                        rbGrabar.Text = ds.Tables["Tabla"].Rows[0]["grabar"].ToString();
                        rbActualizar.Text = ds.Tables["Tabla"].Rows[0]["modificar"].ToString();
                        rbBorrar.Text = ds.Tables["Tabla"].Rows[0]["eliminar"].ToString();

                        /* TXTCHO_MODELO.Text = ds.Tables["Tabla"].Rows[0]["CHO_MODELO"].ToString();
                         TXTCHO_TELEFONO.Text = ds.Tables["Tabla"].Rows[0]["CHO_TELEFONO"].ToString();
                         TXTCHO_COLOR.Text = ds.Tables["Tabla"].Rows[0]["CHO_COLOR"].ToString();*/
                        // TXTLOT_LOTE.Select(TXTLOT_LOTE.Text.Length, 0);

                    }
                    else

                        MessageBox.Show("No Existe este dato");
                    txtIdPer.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }

            }
        }

        private void rbGrabar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripGuardar_Click(object sender, EventArgs e)
        {
            Grabar();
        }
        private void Grabar()
        {
            if (string.IsNullOrEmpty(txtIdPer.Text) || string.IsNullOrEmpty(txtId_rol.Text) || string.IsNullOrEmpty(txtId_modu.Text) || string.IsNullOrEmpty(txtNomModu.Text) || string.IsNullOrEmpty(txtNomRol.Text))
            {
                MessageBox.Show("Debe completar la información");
                return;
            }

            Clases.Cpermisos B = new Clases.Cpermisos(Convert.ToInt32(txtIdPer.Text));
            DataSet ds = new DataSet();
            c = new Clases.Cconexion(B.CONSULTARI());
            ds = c.consultar();
            g = new Clases.Cpermisos();

            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new Clases.Cconexion(g.modificar());
            else
                c = new Clases.Cconexion(g.GRABAR());
            MessageBox.Show(c.Ejecutar());
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            txtIdPer.Clear();
            txtId_modu.Clear();
            txtId_rol.Clear();
            txtNomModu.Clear();
            txtNomRol.Clear();
        }

        private void toolStripSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
