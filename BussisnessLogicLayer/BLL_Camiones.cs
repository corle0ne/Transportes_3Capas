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

 
        //DELETE
    }
}
