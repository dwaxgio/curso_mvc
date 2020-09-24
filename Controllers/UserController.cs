using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.TableViewModels;

namespace CursoMVC.Controllers
{
    // 9. Agrego controlador para usuarios
    public class UserController : Controller
    {
        
        // GET: User
        public ActionResult Index()
        {
            // 12. Se muestra la información de la siguiente manera:
            List<UserTableViewModel> lst = null; // Creo lista de UserTableViewModel vacia
            using (CursomvcEntities db = new CursomvcEntities())
            {
                // Se llena lista
                lst = (from d in db.user
                      where d.idState == 1
                      orderby d.email
                      select new UserTableViewModel
                      {
                          Email = d.email, //Paso los valores de la consulta, y los asigno a los atributos creados en la clase UserTableViewModel
                          Id = d.id,
                          Edad = d.edad
                      }).ToList(); // Luego de lst = se cierra todo entre parentesis, dado que se va a convertir en lista el resultado mediante .ToList()

            }

            return View(lst);
        }
    }
}