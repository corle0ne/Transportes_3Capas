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


        //READ

        public static List<Camiones_VO> Get_Camiones(params object[] parametros) { 
        
           return DAL_Camiones.Get_Camiones(parametros);
        
        }

        //UPDATE


        //DELETE
    }
}
