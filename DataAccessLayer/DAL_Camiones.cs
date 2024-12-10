﻿using System;
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

        public static string crud_Camion(Camiones_VO camion, string accion)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_Camiones",
                    "@Matricula", camion.Matricula,
                    "Tipo_Camion", camion.Tipo_Camion,
                    "@Marca", camion.Marca,
                    "@Modelo", camion.Modelo,
                    "@Capacidad", camion.Capacidad,
                    "@Kilometraje", camion.Kilometraje,
                    "@UrlFoto", camion.UrlFoto,
                    "@Disponibilidad", camion.Disponibilidad,
                    "@accion", accion
                    );

                if (respuesta != 0)
                {
                    salida = "Camion registrado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = $"Error; {e.Message}";
            }
            return salida;
        }

        //READ

        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            //creo una lista de objetos VO
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {

                //creo un dataset el cual recibira lo que devuelva la ejecucion del metodo "execute_dataset" de la clase "metodos_datos"
                DataSet ds_camiones = metodos_datos.execute_DataSet("sp_ListarCamiones", parametros);
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

        public static string actualizar_Camion(Camiones_VO camion)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_Camiones",
                    "@Matricula", camion.Matricula,
                    "Tipo_Camion", camion.Tipo_Camion,
                    "@Marca", camion.Marca,
                    "@Modelo", camion.Modelo,
                    "@Capacidad", camion.Capacidad,
                    "@Kilometraje", camion.Kilometraje,
                    "@UrlFoto", camion.UrlFoto,
                    "@Disponibilidad", camion.Disponibilidad,
                    "@Id_Camion", camion.ID_Camion
                    );

                if (respuesta != 0)
                {
                    salida = "Camion registrado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = $"Error; {e.Message}";
            }
            return salida;
        }


        //DELETE

        public static string eliminar_Camion(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_Camiones",
                    "@Id_Camion", id 
                    );

                if (respuesta != 0)
                {
                    salida = "Camion registrado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = $"Error; {e.Message}";
            }
            return salida;
        }
    }
}
