using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
     class Cdatosg
    {
        private string nom_empresa;
        private string direccion;
        private string  telefono;
        private string gerente;

        public Cdatosg(string nom_empresa, string direccion , string telefono, string gerente)
        {
            this.nom_empresa = nom_empresa;
            this.direccion = direccion;
            this.telefono = telefono;
            this.gerente = gerente;
        }
        public Cdatosg()
        {

        }

        public Cdatosg(string nom_empresa)
        {
            this.nom_empresa = nom_empresa;
        }

        public string GRABAR()
        {
            return (" insert into datosg values ('" + this.nom_empresa + "','" + this.direccion + "' ," + this.telefono + "' ," + this.gerente + "' ,");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  datosg WHERE nom_empresa = '" + this.nom_empresa + "'");
        }
        public string modificar()
        {
            return ("update datosg set datosg = '" + this.nom_empresa+ "', '" + this.telefono + "', '" + this.gerente + "' where nom_empresa ='" + this.direccion + "'");
        }
    
        public string Consultageneral()
        {
            return ("select nom_empresa as nom_empresa, direccion as direccion, telefono as telefono, gerente as gerente from datosg");
        }

        public string Consecutivo()
        {
            return ("select MAX(nom_empresa) + 1 as folio from datosg");
        }
}
}
