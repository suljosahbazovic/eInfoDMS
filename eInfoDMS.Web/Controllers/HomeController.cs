using eInfoDMS.Data.Models;
using eInfoDMS.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eInfoDMS.Web.Controllers
{
    public class HomeController : Controller
    {
        // Ovo je ulazna tačka za url http://adresa-servera/
        // GET: Home
        public ActionResult Index()
        {
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);

            if (k == null)
                return RedirectToAction("Logout", "Autentifikacija", new { area = "" });

            if (k.Zaposlenik != null)
                return RedirectToAction("Index", "Home", new { area = "ModulZaposlenik" });            

            return RedirectToAction("Logout", "Autentifikacija", new { area = "" });
        }
    }
}