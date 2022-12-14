using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    public class Cmodulos
    {
        private byte id_nombre;
        private string nom_modulo;

        public Cmodulos(byte id_nombre, string nom_modulo)
        {
            this.id_nombre = id_nombre;
            this.nom_modulo = nom_modulo;
        }
        public Cmodulos(byte id_nombre)
        {
            this.id_nombre = id_nombre;
        }
        public Cmodulos()
        {

        }
        public string GRABAR()
        {
            return (" insert into modulos values ('" + this.id_nombre + "','" + this.nom_modulo + "')");
        }
        public string consultar()
        {
            return (" SELECT * FROM  modulos WHERE id_nombre= '" + this.id_nombre + "'");
        }
        public string modificar()
        {
            return (" update modulos set  nombre_modulo ='" + this.nom_modulo + "' WHERE id_nombre = '" + this.id_nombre + "'");
        }
        public string ConsultaGeneral()
        {
            return (" SELECT id_nombre as id_nombre , nombre_modulo as nombre_modulo FROM  modulos");

        }

        public string consecutivo()
        {
            return ("select MAX(id_nombre) + 1 as folio from modulos");
        }
        

    }
}

