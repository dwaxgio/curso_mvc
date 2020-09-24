using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.TableViewModels
{
    // 10. Agrego ViewModel para traer solo datos que requiero de la/las tablas, estableciendo los atributos que requiero
    public class UserTableViewModel
    {
        public int Id { get; set; } 
        public string Email { get; set; }
        public int? Edad { get; set; } // simbolo ? para indicar que campo sea nullable
    }
}