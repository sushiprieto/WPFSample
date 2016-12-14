using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WPFSample_BL.Listados;
using WPFSample_BL.Manejadoras;
using WPFSample_Ent;

namespace WPFSample_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            clsListadoPersonaBL misListados = new clsListadoPersonaBL();
            return View(misListados.ListadoPersonasBL());
        }

        /// <summary>
        /// retomamos la vista de create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// llamamos a un objeto persona y creamos la lista
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(clsPersona p)
        {

            if (!ModelState.IsValid)
            {
                return (Create(p));
            }
            else
            {
                clsManejadoraPersonaBL miManejadora = new clsManejadoraPersonaBL();
                miManejadora.insertPersonaBL(p);
                clsListadoPersonaBL lista = new clsListadoPersonaBL();
                return View("Index", lista.ListadoPersonasBL());
            }
        }

       /// <summary>
       /// recuperamos el id del objeto persona, buscamos esa persona y se la enviamos a la vista
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public ActionResult Delete(int id)
        {
            return View("Delete");
        }

        /// <summary>
        /// Volvemos a recoger el campo de la ruta url y ya hacemos el borrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            clsManejadoraPersonaBL miManejadora = new clsManejadoraPersonaBL();
            clsListadoPersonaBL miLista = new clsListadoPersonaBL();
            miManejadora.deletePersonaBL(id);
            return View("Index", miLista.ListadoPersonasBL());
        }

        /// <summary>
        /// Recibimos el id de la persona, hacemos un foreach para volver a mostrar los datos de los campos y poder 
        /// modificarlos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            clsPersona p = new clsPersona();
            
            foreach (clsPersona persona in new clsListadoPersonaBL().ListadoPersonasBL())
            {
                if (persona.id == id)
                {
                    p.Nombre = persona.Nombre;
                    p.Apellidos = persona.Apellidos;
                    p.FechaNac = persona.FechaNac;
                    p.Telefono = persona.Telefono;
                    p.Direccion = persona.Direccion;
                }
            }
            return View(p);
        }

        /// <summary>
        /// Recojo los valores del formulario que coinciden con la persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(clsPersona persona)
        {
            clsManejadoraPersonaBL miManejadora = new clsManejadoraPersonaBL();
            miManejadora.updatePersonaBL(persona);

            return View("Index", new clsListadoPersonaBL().ListadoPersonasBL());
        }

        /// <summary>
        /// Recibimos un id para mostrar la lista de detalles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            clsManejadoraPersonaBL miManejadora = new clsManejadoraPersonaBL();
            clsPersona p = miManejadora.selectPersonaBL(id);
            return View(p);
        }

    }
}