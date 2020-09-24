using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.ViewModels
{
    // 22. Creo ViewModel para el cargue de los archivos
    public class ArchivoViewModel
    {
        // Estos ´harian relacion a los "campos" que se van a remitir desde un formulario
        [Required]
        [DisplayName("Mi archivo")] // es lo que aparecerá en el label
        public HttpPostedFileBase Archivo1 { get; set; }
        [Required]
        [DisplayName("Mi archivo2")]
        public HttpPostedFileBase Archivo2 { get; set; }
        [Required]
        [DisplayName("Mi cadena")]
        public string Cadena { get; set; }
    }
}