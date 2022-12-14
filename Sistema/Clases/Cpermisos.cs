using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    public class Cpermisos
    {
        private int id;
        private int id_rol;
        private byte id_modulo;
        private bool  Consultar;
        private bool grabar;
        private bool actualizar;
        private int borrar;

      
        public Cpermisos(int id)
        {
            this.id = id;
        }

        public Cpermisos(int id, int id_rol, byte id_modulo, bool Consultar, bool grabar, bool actualizar, int borrar)
        {
            this.id = id;
            this.id_rol = id_rol;
            this.id_modulo = id_modulo;
            this.Consultar = Consultar;
            this.grabar = grabar;
            this.actualizar = actualizar;
            this.borrar = borrar;
        }
        public Cpermisos()
        {

        }

        public string GRABAR()
        {
            return (" insert into permisos values ('" + this.id_rol + "','" + this.id_modulo + "' ," + this.Consultar + "' ," + this.grabar + "' ," + this.actualizar + "' ," + this.borrar + "' ,");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  permisos WHERE id = '" + this.id_modulo + "'");
        }
        public string modificar()
        {
            return (" update permisos set permisos = '" + this.id_modulo + "' WHERE id = '" + this.id_modulo + "'");
        }
        public string consultageneral()
        {
            return (" SELECT id as id , permisos as permisos FROM permisos");
        }

        public string consecutivo()
        {
            return ("SEELCT MAX(IDROL)+ 1 FROM ROL" +
                "");

        }
    }
}
