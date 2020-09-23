using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class AccessController : Controller
    {
        // 1. Creo controlador Access, automaticamente, crea vista
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        // 4. Agrego metodo para el acceso, recibe información de formulario de index de access
        public ActionResult Enter(string user, string password) // Los parametros son los Name del Index de Access
        {
            try
            {
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message); // Content es un metodo que retorna un texto, en vez de una vista
            }            
        }
    }
}