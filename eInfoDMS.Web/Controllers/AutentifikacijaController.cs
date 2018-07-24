using eInfoDMS.Data.DAL;
using eInfoDMS.Data.Models;
using eInfoDMS.Web.Helper;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using eInfoDMS.Web.Models;
using System.Web.Security;

namespace eInfoDMS.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private MyContext ctx = new MyContext();
        
        public ActionResult Index()
        {
            //Vraća view iz Views\Login\Index.cshtml
            return View();
        }
        
        public ActionResult Provjera(string username, string password, string zapamti) //string username, string password, string zapamti
        {
            Korisnik k = ctx.Korisniks
                .Include(x => x.Zaposleniks.Select(y => y.Zaposlenja))
                .SingleOrDefault(x => x.KorisnickoIme == username && x.Lozinka == password);

            if (k == null)
            {
                return RedirectToAction("Index");
            }

            Autentifikacija.PokreniNovuSesiju(k, HttpContext, (zapamti == "on"));

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Autentifikacija.PokreniNovuSesiju(null, HttpContext, true);
            return RedirectToAction("Index");
        }
    }
}