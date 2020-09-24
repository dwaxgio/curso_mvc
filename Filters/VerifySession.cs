using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Controllers;
using CursoMVC.Models;

namespace CursoMVC.Filters
{
    // 6. Agrego Clase filtro para verificar sesión, que herede de ActionFilterAttribute
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (user)HttpContext.Current.Session["User"]; // Trae la información de la sesión actual
            if(oUser == null)
            {
                if (filterContext.Controller is AccessController == false)  // Si peticion llega a la ruta diferente a AccesController, ejecute lo siguiente
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index"); //Devuelva la peticion a la página de login
                }                
            }
            else
            {
                if (filterContext.Controller is AccessController == true)  // Si peticion llega a la ruta a AccesController, y ya se encuentra con usuario de sesion:
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index"); //Dirija a home
                }
            }
            // De lo contrario, entra directo al metodo de la clase base
            base.OnActionExecuting(filterContext);
        }
    }
}