using System.Web;
using System.Web.Mvc;

namespace CursoMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // 7. Se agrega lo siguiente, para implementar filtro creado VerifySession
            filters.Add(new Filters.VerifySession());
        }
    }
}
