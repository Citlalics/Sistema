using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    class Usuario

    {
        private string NOMBRE;
        private string CONTRASEÑA;

        public Usuario(string nOMBRE, string cONTRASEÑA)
        {
            this.NOMBRE = nOMBRE;
            this.CONTRASEÑA = cONTRASEÑA;
        }

        public Usuario(string nOMBRE)
        {
            this.NOMBRE = nOMBRE;
        }

        //private string usu_nom;

        public Usuario()
        {

        }


        public string GRABAR()
        {
            return ("insert into USUARIOS values ('" + this.NOMBRE + "','" + this.CONTRASEÑA + "')");
        }
        public string CONSULTARI()
        {
            return ("SELECT * FROM USUARIOS WHERE NOMBRE =  '" + this.NOMBRE + "' AND CONTRASEÑA = dbo.MD5('" + this.CONTRASEÑA + "')");
        }
        public string modificar()
        {
            return ("UPDATE USUARIOS set USUARIO ='" + this.NOMBRE + "' WHERE CONTRASEÑA = '" + this.CONTRASEÑA + "'");
        }
        public string consultageneral()
        {
            return (" SELECT IDUSUARIO as IDUSUARIO, NOMBRE as NOMBRE, CONTRASEÑA as CONTRASEÑA, IDROL as IDROL FROM  USUARIO");
        }
        public string consecutivo()
        {
            return ("select MAX(IDUSUARIO) + 1 as folio from USUARIOS ");
        }
    }
}
