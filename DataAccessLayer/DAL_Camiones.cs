using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewObjects;

namespace DataAccessLayer
{
    public class DAL_Camiones
    {
        //CREATE



        //READ

        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            //creo una lista de objetos VO
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {

                //creo un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_dataset" de la clase "metodos_datos"
                DataSet ds_camiones = metodos_datos.execute_DataSet("SP_Listar_Camiones", parametros);
                //recorro cara renglon existente de nuestro ds creando objetos del tipo VO y añadiendolos a la lista
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {

                    list.Add(new Camiones_VO(dr));

                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //UPDATE
        
        
        
        //DELETE
    }
}
