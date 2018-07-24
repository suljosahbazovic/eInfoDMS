using eInfoDMS.Data.Models;
using eInfoDMS.Web.Helper;
using System.Web.Mvc;

namespace eInfoDMS.Web.Areas.ModulSuperAdmin.Controllers
{
    [Autorizacija(zaposlenikKorisnickaUlogas: new[] { KorisnickaUloga.SuperAdministrator })]
    public class HomeController : Controller
    {
        // GET: ModulAdministracija/HomeAdministracija
        public ActionResult Index()
        {
            return View();
        }
    }
}