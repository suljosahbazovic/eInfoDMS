using eInfoDMS.Data.DAL;
using System.Collections.Generic;

namespace eInfoDMS.Data.Models
{
    public enum KorisnickaUloga
    {
        SuperAdministrator,
        AdministratorInstitucije,
        Edukator,
        RadnikOpstePrakse,
        DirektorInstituta,
        BezPrivilegije
    }
    public class Zaposlenik : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
        public List<Zaposlenje> Zaposlenja { get; set; }
    }
}
