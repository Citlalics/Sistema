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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Globalization;
using System.Data.Common;
using Sistema.Catalogos;

namespace Sistema.Formularios
{
    public partial class FRroles : Form
    {
        public FRroles()
        {
            InitializeComponent();
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            cargarfolio();
        }

        void cargarfolio()
        {
            
            B = new Clases.Croles();
            DataSet ds = new DataSet();
            
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            busca();
        }

        Clases.Croles g;
        
        private void busca()
        {
            try
            {
                g = new Clases.Croles();
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
        Clases.Croles B;

        private void consultar()
        {
            if (!(txtclave.Text == ""))
            {
                try
                {
                    B = new Clases.Croles(byte.Parse(txtclave.Text));
                    DataSet ds = new DataSet();
                    c = new Clases.Cconexion(B.consultar());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        txtclave.Text = ds.Tables["Tabla"].Rows[0]["IDROL"].ToString();
                        txtnombre.Text = ds.Tables["Tabla"].Rows[0]["DESCRIPCION"].ToString();
                        //TXTCHO_MODELO.Text = ds.Tables["Tabla"].Rows[0]["CHO_MODELO"].ToString();
                        //TXTCHO_TELEFONO.Text = ds.Tables["Tabla"].Rows[0]["CHO_TELEFONO"].ToString();
                        //TXTCHO_COLOR.Text = ds.Tables["Tabla"].Rows[0]["CHO_COLOR"].ToString();
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

        private void toolStripGuardar_Click(object sender, EventArgs e)
        {
            graba();
        }

        private void graba()
        {
            Clases.Croles B = new Clases.Croles(byte.Parse(txtclave.Text));
            DataSet ds = new DataSet();
            c = new Clases.Cconexion(B.consultar());
            ds = c.consultar();
            g = new Clases.Croles(byte.Parse(txtclave.Text), txtnombre.Text);
            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new Clases.Cconexion(g.modificar());
            else
                c = new Clases.Cconexion(g.GRABAR());
            MessageBox.Show(c.Ejecutar());
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripImprimir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Catalogos.Reporte orptPrueba;
            ConnectionInfo oConexInfo;
            Tables oListaTablas;
            TableLogOnInfo oTablaConexInfo;
            oConexInfo = new ConnectionInfo();
            oConexInfo.ServerName = Clases.Cglobal.server;
            oConexInfo.DatabaseName = Clases.Cglobal.DB;

            Boolean IntegratedSecurity = false;
            oConexInfo.IntegratedSecurity = IntegratedSecurity;
            oConexInfo.UserID = Clases.Cglobal.usuario;
            oConexInfo.Password = Clases.Cglobal.password;
            oConexInfo.DatabaseName = Clases.Cglobal.DB;
            oConexInfo.Type = ConnectionInfoType.Query;

            //orptPrueba = new rptventasperiodo();
            orptPrueba = new Reporte();
            oListaTablas = orptPrueba.Database.Tables;
            foreach (Table roTabla in oListaTablas)
            {
                oTablaConexInfo = roTabla.LogOnInfo;
                oTablaConexInfo.ConnectionInfo = oConexInfo;
                roTabla.ApplyLogOnInfo(oTablaConexInfo);
            }

            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;


            /*if (!(string.IsNullOrEmpty(txtboletai.Text)))
                orptPrueba.SetParameterValue("@FOLIOBOLETA", int.Parse(txtboletai.Text));
            else
                MessageBox.Show("Por favor introduzca el Número de Boleta", "Advertencia",
    MessageBoxButtons.OK,
    MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button1);


            x.crystalReportViewer1.ReportSource = orptPrueba;
            x.ShowDialog();
            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
            */
        }

        private void toolStripSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            txtclave.Clear();
            txtnombre.Clear();
        }
    }   
}
