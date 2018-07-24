using eInfoDMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInfoDMS.Data.DAL
{
    public class MyContext : DbContext
    {
        public MyContext() : base("Name=ConnectionString")
        {

        }

        public DbSet<Korisnik> Korisniks { get; set; }
        public DbSet<Zaposlenik> Zaposleniks { get; set; }
        public DbSet<Zaposlenje> Zaposlenjes { set; get; }
        public DbSet<ZaposlenjeMjesto> ZaposlenjeMjestos { set; get; }
    }
}
