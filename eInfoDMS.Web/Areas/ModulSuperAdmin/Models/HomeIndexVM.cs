using eInfoDMS.Data.Models;
using System;
using System.Collections.Generic;

namespace eInfoDMS.Web.Areas.ModulSuperAdmin.Models
{
    //Klasa koja sadrži podatke o prikazu Zaposlenika HomeIndexViewModel
    public class HomeIndexVM
    {
        public class ZaposlenjaInfo
        {
            public int ZaposlenjeId { get; set; }
            public string ZaposlenjeMjestoNaziv { get; set; }
            public DateTime UgovorPocetak { get; set; }
            public DateTime? UgovorKraj { get; set; }
            public KorisnickaUloga KorisnickaUloga { get; set; }
        }

        public List<ZaposlenjaInfo> TabelaPodaci { get; set; }
    }
}