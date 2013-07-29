using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlataformaVirutalEducativa.Models;

namespace PlataformaVirutalEducativa.Controllers
{
    public class InscripcionesController : Controller
    {
        //
        // GET: /Inscripciones/

        public ActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "Inscripciones")]
        public ActionResult inscripcion(string id)
        {
            int idCur = Convert.ToInt32(id);
            int IdUsuario = Convert.ToInt32(Session["IdUsuario"]);

            Inscripcion ins = new Inscripcion();
            ins.IdCurso = idCur;
            ins.IdUsuario = IdUsuario;

            InscripcionActions contexto = new InscripcionActions();

            if (contexto.InsertarInscripcion(ins))
            {
                return View("ExitoAsignacion");
            };
            return View();
        }
    }
}
