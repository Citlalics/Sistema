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
    public partial class FRmodulos : Form
    {
        public FRmodulos()
        {
            InitializeComponent();
        }

        private void FRmodulos_Load(object sender, EventArgs e)
        {
            cargarfolio();
        }
        void cargarfolio()
        {
            B = new Clases.Cmodulos();
            DataSet ds = new DataSet();
            c = new Clases.Cconexion(B.consultar());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                txtclave.Text = ds.Tables["Tabla"].Rows[0]["id_nombre"].ToString();
                txtnombre.Text = ds.Tables["Tabla"].Rows[0]["nombre_modulo"].ToString();
            }
        }

        private void toolStripBuscar_Click(object sender, EventArgs e)
        {
            busca();
        }
        Clases.Cmodulos g;
        private void busca()
        {
            try
            {
                g = new Clases.Cmodulos();
                Clases.Cconexion con = new Clases.Cconexion();
                if (con.Execute(g.ConsultaGeneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        txtclave.Text = con.FieldValue;
                       consultar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        Clases.Cconexion c;
        Clases.Cmodulos B;
        private void consultar()
        {
            if (!(txtclave.Text == ""))
            {
                try
                {
                    B = new Clases.Cmodulos(byte.Parse(txtclave.Text));
                    DataSet ds = new DataSet();
                    c = new Clases.Cconexion(B.consultar());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        txtclave.Text = ds.Tables["Tabla"].Rows[0]["id_nombre"].ToString();
                        txtnombre.Text = ds.Tables["Tabla"].Rows[0]["nombre_modulo"].ToString();
          
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

        private void toolStripGuardar_Click(object sender, EventArgs e)
        {
            Graba();
        }
        private void Graba()
        {
            
            if (string.IsNullOrEmpty(txtclave.Text) || string.IsNullOrEmpty(txtnombre.Text))
            {
                MessageBox.Show("Debe completar la información");
                return;
            }

            Clases.Cmodulos B = new Clases.Cmodulos(byte.Parse(txtclave.Text));
            DataSet ds = new DataSet();
            c = new Clases.Cconexion(B.consultar());
            ds = c.consultar();
            g = new Clases.Cmodulos(byte.Parse(txtclave.Text), txtnombre.Text);

            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new Clases.Cconexion(g.modificar());
            else
                c = new Clases.Cconexion(g.GRABAR());
            MessageBox.Show(c.Ejecutar());
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            txtclave.Clear();
            txtnombre.Clear();
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

