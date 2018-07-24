using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using eInfoDMS.Data.DAL;

namespace eInfoDMS.Web.Models
{
    public class LoginVM
    {
        private MyContext ctx = new MyContext();
        public string GetUserPassword(string korisnickoIme)
        {
            var user = from o in ctx.Korisniks where o.KorisnickoIme == korisnickoIme select o;
            if (user.ToList().Count > 0)
                return user.First().Lozinka;
            else
                return string.Empty;
        }    
    }
}