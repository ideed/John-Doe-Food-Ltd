using System.Web;
using System.Web.Mvc;

namespace John_Doe_Food_Ltd
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
