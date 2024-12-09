using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class configuracion
    {
        //cadena de conexion
        //data source = nombre del servidor de BD
        //localhost
        //.
        //Nombre de mi instancia
        //Initial Catalog = nombre de la DB
        //Integrated Security = true (Credenciales de la maquina)
        //=false (Credenciales de accesso)
        //Se habilitan los campos de
        //User=''
        //Password=;

        static string _cadenaConexion = @"Data source= DESKTOP-HGPQJRO\SQLEXPRESS ;
                                          Initial Catalog = Transportes;
                                          Integrated Security = true;
                                           ";

        //Encapsulamiento

        public static string CadenaConexion
        {
            get
            {
                return _cadenaConexion;
            }
        }
    }
}
