using eInfoDMS.Data.DAL;

namespace eInfoDMS.Data.Models
{
    public enum ZaposlenjeNacin
    {
        OsnovnoRadnoMjesto,
        DodatnaFunkcija
    }
    public class ZaposlenjeMjesto : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }

        public ZaposlenjeNacin ZaposlenjeNacin { get; set; }
    }
}
