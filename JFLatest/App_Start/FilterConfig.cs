using System.Web;
using System.Web.Mvc;

namespace JFLatest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection JFLatest)
        {
            JFLatest.Add(new HandleErrorAttribute());
        }
    }
}