using eInfoDMS.Data.DAL;
using System;

namespace eInfoDMS.Data.Models
{
    public class Zaposlenje : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public int ZaposlenikId { get; set; }
        public Zaposlenik Zaposlenik { get; set; }

        public DateTime UgovorPocetak { get; set; }
        public DateTime? UgovorKraj { get; set; }

        public int ZaposlenjeMjestoId { get; set; }
        public ZaposlenjeMjesto ZaposlenjeMjesto { get; set; }

        public KorisnickaUloga KorisnickaUloga { get; set; }
    }
}
