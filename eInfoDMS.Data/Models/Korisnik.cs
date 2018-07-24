using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace eInfoDMS.Data.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        [Display(Name = "KorisnickoIme")]
        [Required(ErrorMessage = "Korisničko ime je obavezno")]
        public string KorisnickoIme { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        [Required(ErrorMessage = "Lozinka je obavezna")]
        public string Lozinka { get; set; }    

        public List<Zaposlenik> Zaposleniks { get; set; }
        public Zaposlenik Zaposlenik
        {
            get
            {
                return Zaposleniks.FirstOrDefault();
            }
        }      

        public string Ime_prezime
        {
            get { return Ime + " " + Prezime; }
        }

        public string Prezime_ime
        {
            get { return Prezime + " " + Ime; }
        }
    }
}
