using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class metodos_datos
    {
        //metodo para ejecutar un dataset
        //utilizado para ejecutar una consulta sql que devuelve un conjunto de datos
        //que puede contener una o varias tablas con filas y columnas de datos

        public static DataSet execute_DataSet(string sp, params object[] parametros)
        {
            //instanciamos un DS 
            DataSet ds = new DataSet();
            //obtenemos la cadena de conexion
            string conn = configuracion.CadenaConexion;
            //creamos conexion => Sqlconnection Objeto de ADO

            SqlConnection SQLCon = new SqlConnection(conn);

            try
            {
                if (SQLCon.State == ConnectionState.Open)
                {

                    SQLCon.Close();

                }
                else
                {
                    //comando para SQL (sp, conexion) => SqlCommand objeto de ADO
                    SqlCommand cmd = new SqlCommand(sp,SQLCon);
                    //defino que el comando sera ejecutado como una sp (stored procedure)
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    //validamos si existen y estan completos los parametros
                    //si es diferente de null y su residuo es diferente de 0
                    //parametros = {clave:valor}
                    if (parametros != null && parametros.Length % 2 != 0) {

                        throw new Exception("Los parametros deben estar en pares (clave:valor)");


                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for(int i=0;i<parametros.Length;i++){
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i+1].ToString());
                        }

                        SQLCon.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds);
                        SQLCon.Close();
                    }
                }

                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open)
                {

                    SQLCon.Close();

                }
            }
        }

        //metodo que ejectuta un escalar
        //ejecuta una consulta SQL que devuelve un solo valor o una sola columna de datos
        //retorna el valor de la primera colmna y la primera fila del conjunto de rsultados
        public static int execute_Scalar(string sp, params object[] parametros)
        {
            //instanciamos un DS 
            int id=0;
            //obtenemos la cadena de conexion
            string conn = configuracion.CadenaConexion;
            //creamos conexion => Sqlconnection Objeto de ADO

            SqlConnection SQLCon = new SqlConnection(conn);

            try
            {
                if (SQLCon.State == ConnectionState.Open)
                {

                    SQLCon.Close();

                }
                else
                {
                    //comando para SQL (sp, conexion) => SqlCommand objeto de ADO
                    SqlCommand cmd = new SqlCommand(sp, SQLCon);
                    //defino que el comando sera ejecutado como una sp (stored procedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    //validamos si existen y estan completos los parametros
                    //si es diferente de null y su residuo es diferente de 0
                    //parametros = {clave:valor}
                    if (parametros != null && parametros.Length % 2 != 0)
                    {

                        throw new Exception("Los parametros deben estar en pares (clave:valor)");


                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        SQLCon.Open();
                        id = int.Parse(cmd.ExecuteScalar().ToString());
                        SQLCon.Close();
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open)
                {

                    SQLCon.Close();

                }
            }
        }


        //meotodo que se ejecuta un nonquery
        //utilizado para ejecutar consultas sql que no devuelven un conjunto de resultados
        //como sentencias INSERT, UPDATE, O DELETE
        //retorna un valor entero que respresenta el numero de filas afectadas por la operacion
        //por ejemplo el numero de filas insertadasd actualizadas o eliminadas

        public static int execute_nonQuery(string sp, params object[] parametros)
        {
            //instanciamos un DS 
            int id = 0;
            //obtenemos la cadena de conexion
            string conn = configuracion.CadenaConexion;
            //creamos conexion => Sqlconnection Objeto de ADO

            SqlConnection SQLCon = new SqlConnection(conn);

            try
            {
                if (SQLCon.State == ConnectionState.Open)
                {

                    SQLCon.Close();

                }
                else
                {
                    //comando para SQL (sp, conexion) => SqlCommand objeto de ADO
                    SqlCommand cmd = new SqlCommand(sp, SQLCon);
                    //defino que el comando sera ejecutado como una sp (stored procedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    //validamos si existen y estan completos los parametros
                    //si es diferente de null y su residuo es diferente de 0
                    //parametros = {clave:valor}
                    if (parametros != null && parametros.Length % 2 != 0)
                    {

                        throw new Exception("Los parametros deben estar en pares (clave:valor)");


                    }
                    else
                    {
                        //asignamos los parametros al comando
                        for (int i = 0; i < parametros.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        SQLCon.Open();
                        //ejecuto el comando sin esperar retorno

                        cmd.ExecuteNonQuery();
                        id = 1;

                        SQLCon.Close();
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                if (SQLCon.State == ConnectionState.Open)
                {

                    SQLCon.Close();

                }
            }
        }

    }



        
}
