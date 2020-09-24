using CursoMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    // 21. Creo controlador (luego de crear carpeta Files) para gestionarlos, no es necesario el uso de db
    public class ArchivoController : Controller
    {
        // GET: Archivo
        public ActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString(); // ViewBag sólo vive en la vista que se está invocando
            }
            return View();
        }

        // 24. Creo método que recibirá la información del formulario
        [HttpPost]
        public ActionResult Save(ArchivoViewModel model)
        {
            string RutaSitio = Server.MapPath("~/");
            string PathArchivo1 = Path.Combine(RutaSitio + "/Files/archivo1.png");
            string PathArchivo2 = Path.Combine(RutaSitio + "/Files/archivo2.png");

            if (!ModelState.IsValid)
            {
                return View("Index", model); // Si la información enviada por el modelo no es valida, entonces redirija a Index, con la información que se haya llenado de model
            }

            // Para guardar en carpeta Files
            model.Archivo1.SaveAs(PathArchivo1);
            model.Archivo2.SaveAs(PathArchivo2);

            @TempData["Message"] = "Se cargaron los archivos";
            return RedirectToAction("Index");
        }
    }
}