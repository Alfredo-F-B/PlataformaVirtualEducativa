using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlataformaVirutalEducativa.Models;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using PlataformaVirutalEducativa.Filters;


namespace PlataformaVirutalEducativa.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class SesionController : Controller
    {


        //GET: /Sesion/

        public ActionResult Index()
        {
            PlataformaEntities server = new PlataformaEntities();
            int id = (int)Membership.GetUser().ProviderUserKey;
            var cursos = (from cur in server.Curso where cur.IdUsuario == id select cur);
            ViewBag.t = cursos.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Sesion model)
        {
            PlataformaEntities server = new PlataformaEntities();
            if (ModelState.IsValid)
            {
                Sesion se = new Sesion();
                se.NombreSesion = model.NombreSesion;
                DateTime ti = DateTime.Now;
                String hora = ti.Hour.ToString();
                server.Sesion.Add(se);
                server.Sesion.Add(model);
                server.SaveChanges();
                return View("SesionCreada");
                //return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
