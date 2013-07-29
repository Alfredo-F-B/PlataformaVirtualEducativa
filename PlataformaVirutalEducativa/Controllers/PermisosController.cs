using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using PlataformaVirutalEducativa.Models;

namespace PlataformaVirutalEducativa.Controllers
{
    public class PermisosController : Controller
    {
        //
        // GET: /Permisos/

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                AdminActions contexto = new AdminActions();
                List<PermisosDeMenu> permisos=new List<PermisosDeMenu>();
                if (Session["IdUsuario"] != null)
                    permisos = contexto.getPermisos(Convert.ToInt32(Session["IdUsuario"]));
                ViewBag.Menus = permisos;
            }
            return View();
        }

    }
}
