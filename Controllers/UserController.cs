using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.TableViewModels;
using CursoMVC.Models.ViewModels;

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

        // 15. Se agrega nuevo metodo, y otro igual, que recibe parametros
        [HttpGet] 
        public ActionResult Add() // En este método, se remite a la vista de formulario desde el que se ENVÍA la información 
        {
            return View();
        }

        [HttpPost] // Metodo para que información solo entre por post
        public ActionResult Add(UserViewModel model) // En este método, se RECIBE la información desde el formulario
        {
            // 16. se valida la información recibida y se guarda en la DB
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            
            //guardado en DB
            using (var db = new CursomvcEntities())
            {
                user oUser = new user(); // Como voy a registrar un nuevo usuario, instancio el objeto, y empiezo a asignarle sus valores, acorde al modelo
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                db.user.Add(oUser);

                db.SaveChanges(); // Importante incluir metodo SaveChanges, para que quede almacenado el registro
            }

            // Una vez almacenado el registro, se re dirige a la vista del listado de usuarios, mediante el metodo Index() de este controlador
            return Redirect(Url.Content("~/User/"));
        }
    }
}