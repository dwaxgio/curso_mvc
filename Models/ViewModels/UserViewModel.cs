using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // para usar anotaciones []

namespace CursoMVC.Models.ViewModels
{
    // 14. se agrega ViewModel para User para crud (para llenar el formulario)
    public class UserViewModel
    {
        [Required]
        [EmailAddress] //Valida que sea correo
        [Display(Name = "Correo Electrónico")]
        [StringLength(100,ErrorMessage ="El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Email{ get; set; }

        [Required]
        [DataType(DataType.Password)] // Ya se inclye como contraseña en la petición
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirma contraseña")]
        [DataType(DataType.Password)] // Ya se inclye como contraseña en la petición
        [Compare("Password",ErrorMessage ="Las contraseñas no son iguales")]
        public string ConfirmPassword{ get; set; }

        [Required]
        public int Edad { get; set; }
    }
}