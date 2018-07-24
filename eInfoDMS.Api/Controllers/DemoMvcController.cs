using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using eInfoDMS.Data.DAL;
using eInfoDMS.Data.Models;


namespace eInfoDMS.Api.Controllers
{
    public class DemoMvcController : ApiController
    {
        // GET: DemoMvc
        [HttpGet]
        public List<Korisnik> Get()
        {
            MyContext ctx = new MyContext();

            List<Korisnik> student = ctx.Korisniks.ToList();
            return student;
        }
    }
}