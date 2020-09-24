using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models; // Importo "carpeta" para poder acceder a los modelos

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
                // 5. Luego de agregar EF en Models, procedo a realizar la siguiente validación
                using (CursomvcEntities db = new CursomvcEntities()) // Creo mi objeto EF
                {
                    var lst = from d in db.user // d es un alias, sería como el SELECT, el in seria como el FROM
                              where d.email == user && d.password == password && d.idState == 1
                              select d; // select d trae todo lo de la tabla users, podria definir un campo en especifico asi: select d.password

                              if(lst.Count() > 0) // valida si se encuentra el registro en la db
                              {
                                    user oUser = lst.First();
                                    Session["User"] = oUser; // Session["User"] es como se maneja dato de sesión en C#
                                    return Content("1");
                    }
                              else
                              {
                                 return Content("Usuario inválido");
                              }
                }


                
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message); // Content es un metodo que retorna un texto, en vez de una vista
            }            
        }

        

    }
}