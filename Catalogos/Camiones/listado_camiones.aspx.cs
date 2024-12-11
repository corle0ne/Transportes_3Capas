using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussisnessLogicLayer;

namespace Transportes_3Capas.Catalogos.Camiones
{
    public partial class listado_camiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //utilizamos la variable "IsPosBack" para controlar la pimera vez que carga la pagina
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }

        public void cargarGrid()
        {
            GVCamiones.DataSource = BLL_Camiones.Get_Camiones();
            GVCamiones.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("formulariocamiones.aspx");
        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino si el comando (el click que se detecta) tiene la propiedad "select"
            if (e.CommandName=="Select")
            {
                //recupero el indice en funcion de aquel elemento que haya detonado el evento
                int varIndex=int.Parse(e.CommandArgument.ToString());   
                //recupero el id en funcion del indice que recuperamos anteriormente
                string id = GVCamiones.DataKeys[varIndex].Values["ID_Camion"].ToString();
                //redirecciono al formulario de edicion pasando como parametro el ID
                Response.Redirect($"formulariocamiones.aspx?Id={id}");

            }
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}