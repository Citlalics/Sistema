using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;


namespace Sistema.Clases
{
    //constructor se usa para pasarle valores a un objeto 
    public class Cconexion
    {
        private string sentencial;
        //estas se derivan de la clase System.Data.Sqlclient
        //objeto
        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd;

        public Cconexion()
        {

        }
        //constructor
        public Cconexion(string sentencia1)
        {
            this.sentencial = sentencia1;

        }
        //Metodo 
        public string Ejecutar()
        {
            conn.ConnectionString = Clases.Cglobal.miconexion;
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sentencial;
            cmd.ExecuteNonQuery();
            conn.Close();
            return "Operación exitosa";



        }

       
       
        public DataSet consultar()
        {
            DataSet datos = new DataSet();
            conn = new SqlConnection(Clases.Cglobal.miconexion);
            if (conn.State != ConnectionState.Open)
            {
                conn.Close(); conn.Open();
            }
            SqlDataAdapter resp = new SqlDataAdapter(sentencial, conn);
                resp.Fill(datos, "Tabla");
            conn.Close();
            return datos;

        }
        private string mFieldValue;
        internal string FieldValue
        {
            get { return mFieldValue; }
        }
        internal bool Execute(string SQL, int ColumnNumberToRetrive)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(SQL, Clases.Cglobal.miconexion);
            da.Fill(ds, "Table");

            //Formularios.SearchForm frmSearchForm = new Formularios.Search();
            formularios.SearchForm frmSearchForm = new formularios.SearchForm();
            frmSearchForm.mColNumber = ColumnNumberToRetrive;
            frmSearchForm.mDS = ds;
            ds = null;
            frmSearchForm.ShowDialog();
            if (frmSearchForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                mFieldValue = frmSearchForm.ReturnValue;
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
