using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussisnessLogicLayer;
using ViewObjects;

namespace Transportes_3Capas.Catalogos.Camiones
{
    public partial class formulariocamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //valido si es postback
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Titulo.Text = "Agregar Camion";
                    subtiTulo.Text = "Registro de un nuevo camion";
                    lbldisponibilidad.Visible = false;
                    chkdisponibilidad.Visible = false;
                    imgfoto.Visible = false;
                    lblurlfoto.Visible = false; 
                }
                else
                {
                    //voy actualizar
                    //recuperar el ID que proviene de la url
                    int _id=Convert.ToInt32(Request.QueryString["Id"]);

                    Camiones_VO _camion_original = BLL_Camiones.Get_Camiones("@ID_Camion", _id)[0];

                    //valido que realmente obtenga el objeto y sus valores, de lo contrario, me regreso al formulario

                    if (_camion_original.ID_Camion != 0)
                    {
                        //si encontre el camion  coloco sus values
                        Titulo.Text = "Actualizar camion";
                        subtiTulo.Text = $"Modificar los datos del camion#{_id}";

                        txtmatricula.Text = _camion_original.Matricula;

                        txtcapacidad.Text = _camion_original.Capacidad.ToString();

                        txtKilometraje.Text = _camion_original.Kilometraje.ToString();

                        txttipo.Text = _camion_original.Tipo_Camion.ToString();

                        txtMarca.Text = _camion_original.Marca;

                        txtmodelo.Text = _camion_original.Modelo;

                        chkdisponibilidad.Checked= _camion_original.Disponibilidad;

                        imgfoto.ImageUrl=_camion_original.UrlFoto;

                    }
                    else
                    {
                        Response.Redirect("listado_camiones.aspx");
                    }
                }
            }
        }

        protected void btnsubeimagen_Click(object sender, EventArgs e)
        {
            //este metodo sirve para guardar y almacenar la imagen en el sirver y posteriormente recuperar la info desde la bse de datos
            if (subeimagen.Value != "")
            {
                //recupero el nombre del archivo
                string filename = Path.GetFileName(subeimagen.Value);
                //valido la extension del archivo
                string fileext = Path.GetExtension(filename).ToLower();
                if ((fileext != ".jpg") && (fileext != ".png"))
                {
                    //sweet alert
                }
                else
                {
                    //verifico que existe el directorio en el servidor, para poder almacenar la imagen, de lo contrario procedo a crearlo
                    string pathdir = Server.MapPath("~/Imagenes/Camiones/");

                    //si no existe el directorio, lo creamos
                    if (!Directory.Exists(pathdir))
                    {

                        //creo el directorio
                        Directory.CreateDirectory(pathdir);

                    }

                    //subo la imagen a la carpeta del servidor
                    subeimagen.PostedFile.SaveAs(pathdir + filename);
                    //recuperamos la ruta de la URL que almacenaremos en la DB
                    string urlfoto = "/Imagenes/Camiones/" + filename;

                    //mostramos en pantalla la URL creada
                    this.urlfoto.InnerText = urlfoto;
                    imgcamion.ImageUrl=urlfoto;
                }
            }
            else { 
                
                //SWEET ALERT
            
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";
            try
            {
                //creamos el objeto que enviaremos para actualizar o insertar a las db
                //existen 2 formas de instanciar y llenar un objeto
                //forma 1 (por atributos)

                Camiones_VO _camion_aux = new Camiones_VO();
                _camion_aux.Matricula = txtmatricula.Text;
                _camion_aux.Marca = txtMarca.Text;
                _camion_aux.Tipo_Camion = txttipo.Text;
                _camion_aux.Modelo = txtmodelo.Text;
                _camion_aux.Capacidad = Convert.ToInt32(txtcapacidad.Text);
                _camion_aux.Kilometraje = Convert.ToDouble(txtKilometraje.Text);
                _camion_aux.UrlFoto= imgcamion.ImageUrl;
                _camion_aux.Disponibilidad = chkdisponibilidad.Checked;

                //decido si voy a insertar o actualizar
                if (Request.QueryString["Id"] == null)
                {
                    _camion_aux.Disponibilidad = true;
                    salida = BLL_Camiones.crud_Camion(_camion_aux);
                }
                else
                {
                    //actualizar
                    _camion_aux.ID_Camion=int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Camiones.crud_Camion2(_camion_aux);
                }

                //preparamos la salida para cachar un error y mostrar el sweetalert
                if (salida.ToUpper().Contains("ERROR"))
                {

                }
                else
                {

                }
            }
            catch (Exception ex) { 
            
            
            }

            //sweet alert
        }
    }
}