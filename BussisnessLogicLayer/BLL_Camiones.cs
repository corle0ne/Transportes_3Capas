using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ViewObjects;

namespace BussisnessLogicLayer
{
    public class BLL_Camiones
    {
        //CREATE
        public static string crud_Camion(Camiones_VO camion)
        {
            return DAL_Camiones.crud_Camion(camion, "crear");
        }


        //READ

        public static List<Camiones_VO> Get_Camiones(params object[] parametros) { 
        
           return DAL_Camiones.Get_Camiones(parametros);
        
        }

        //UPDATE

        public static string crud_Camion2(Camiones_VO camion)
        {
            return DAL_Camiones.actualizar_Camion(camion, "actualizar");
        }
        public static string crud_Camion3(int id)
        {
            return DAL_Camiones.eliminar_Camion(id, "eliminar");
        }

        //DELETE
    }
}
