using eInfoDMS.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace eInfoDMS.Web.Helper
{
    public class Autorizacija : FilterAttribute, IAuthorizationFilter
    {
        private readonly bool _allZaposleniks;
        private readonly KorisnickaUloga[] _zaposlenikKorisnickaUlogas;

        public Autorizacija(params KorisnickaUloga[] zaposlenikKorisnickaUlogas)
        {
            _zaposlenikKorisnickaUlogas = zaposlenikKorisnickaUlogas;
        }

        public Autorizacija(bool allZaposleniks)
        {
            _allZaposleniks = allZaposleniks;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(filterContext.HttpContext);

            if (k == null)
            {
                filterContext.HttpContext.Response.Redirect("/Autentifikacija");
                return;
            }

            if (_allZaposleniks && k.Zaposlenik != null)
                return;

            List<Zaposlenje> zaposlenja = Autentifikacija.getZaposlenjes(filterContext.HttpContext);

            if (zaposlenja != null)
            {
                //provjera
                foreach (KorisnickaUloga x in _zaposlenikKorisnickaUlogas)
                {
                    if (zaposlenja.Any(z => z.KorisnickaUloga == x))
                        return;
                }
            }

            //ako funkcija nije prekinuta pomoću "return", onda korisnik nema pravo pistupa pa će se vršiti redirekcija na "/Home/Index"
            filterContext.HttpContext.Response.Redirect("/Autentifikacija");
        }
    }
}