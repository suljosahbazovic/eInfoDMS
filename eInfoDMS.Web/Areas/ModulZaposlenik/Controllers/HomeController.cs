using eInfoDMS.Data.DAL;
using eInfoDMS.Data.Models;
using eInfoDMS.Web.Areas.ModulZaposlenik.Models;
using eInfoDMS.Web.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace eInfoDMS.Web.Areas.ModulZaposlenik.Controllers
{
    //[Autorizacija(zaposlenikKorisnickaUlogas: new[] { KorisnickaUloga.SuperAdministrator, KorisnickaUloga.AdministratorInstitucije, })]
    public class HomeController : Controller
    {
        private MyContext ctx = new MyContext();

        // GET: ModulZaposlenik/Home
        public ActionResult Index()
        {
            int zaposlenikId = Autentifikacija.GetLogiraniKorisnik(HttpContext).Zaposlenik.Id;
            HomeIndexVM model = new HomeIndexVM();
            model.TabelaPodaci = ctx.Zaposlenjes.Where(x => x.ZaposlenikId == zaposlenikId).Select(x => new HomeIndexVM.ZaposlenjaInfo
            {
                ZaposlenjeId = x.ZaposlenikId,
                ZaposlenjeMjestoNaziv = x.ZaposlenjeMjesto.Naziv,
                KorisnickaUloga = x.KorisnickaUloga,
                UgovorPocetak = x.UgovorPocetak,
                UgovorKraj = x.UgovorKraj
            }).ToList();
            return View(model);
        }

        public ActionResult OdabirZaposlenje (int zaposlenjeId)
        {
            Zaposlenje zaposlenje = ctx.Zaposlenjes.Find(zaposlenjeId);

            if (!ImaPravoOdabira(zaposlenje))
                return RedirectToAction("Index");

            switch (zaposlenje.KorisnickaUloga)
            {
                case KorisnickaUloga.SuperAdministrator:
                    return RedirectToAction("Index", "Home", new { area = "ModulSuperAdmin" });

                //case KorisnickaUloga.AdministratorInstitucije:
                //    break;

                //case KorisnickaUloga.Edukator:
                //    break;

                //case KorisnickaUloga.RadnikOpstePrakse:
                //    break;

                //case KorisnickaUloga.DirektorInstituta:
                //    break;

                //case KorisnickaUloga.BezPrivilegije:
                //    break;

                default:
                    return RedirectToAction("Index");
            }
        }

        private bool ImaPravoOdabira(Zaposlenje zaposlenje)
        {
            List<Zaposlenje> zaposlenjes = Autentifikacija.getZaposlenjes(HttpContext);

            if (zaposlenjes.Any(x => x.KorisnickaUloga == KorisnickaUloga.SuperAdministrator))
                return true;

            if (zaposlenjes.Any(x => x.Id == zaposlenje.Id))
                return true;

            return false;
            
        }
    }
}