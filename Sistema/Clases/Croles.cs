using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    public class Croles
    {
        private byte id;
        private string nombre;


        //metodo costructor para grabar y editar
        public Croles(byte id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        //metodo constructor consultar
        public Croles(byte id)
        {
            this.id = id;
        }

        public Croles()
        {

        }


        public string GRABAR()
        {
            return (" insert into Rol values ('" + this.id + "','" + this.nombre + "')");
        }
        public string consultar()
        {
            return (" SELECT * FROM  Rol WHERE IDROL= '" + this.id + "'");
        }
        public string modificar()
        {
            return (" update Rol set  DESCRIPCION ='" + this.nombre + "' WHERE IDROL = '" + this.id + "'");
        }
        public string ConsultaGeneral()
        {
            return (" SELECT IDROL as IDROL , DESCRIPCION as DESCRIPCION FROM  ROL");

        }
        
        public string consecutivo ()
        {
            return ("SEELCT MAX(IDROL)+ 1 FROM ROL" +
                "");
                
        }


    }

}






