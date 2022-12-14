using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    //static es para poder llamar la clase en cualquier parte del proyecto con el punto 
    public static class Cglobal
    {
        static public string server = "Citlali-cs";
        static public string DB = "BDPIZZAHOUSE";
        static public string usuario = "sa";
                                        
        static public string password = "Ccs301003";
        
        static public string miconexion = @"Data source =" + server + "; initial catalog =" + DB +  "; persist security info = true ; User ID =SA; Password =" + password;

        /*static public byte nivel = 0;
        static public bool nive = false;
        static public string lusuario = "";
        static public string lnombre = "";
        static public string lpuesto = "";*/



    }
}
