using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eInfoDMS.Data.Models;
using eInfoDMS.Data.DAL;

namespace eInfoDMS.Api.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // GET: DemoMvc
        public ActionResult Index()
        {
            MyContext ctx = new MyContext();

            List<Zaposlenik> students = ctx.Zaposleniks.ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
            //List<Korisnik> korisnik = ctx.Korisniks.ToList();
            //return Json(korisnik, JsonRequestBehavior.AllowGet);
        }
    }
}