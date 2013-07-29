using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PlataformaVirutalEducativa.Models;

namespace PlataformaVirutalEducativa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                AdminActions contexto = new AdminActions();
                List<PermisosDeMenu> permisos = new List<PermisosDeMenu>();
                if (Session["IdUsuario"] != null)
                    permisos = contexto.getPermisos(Convert.ToInt32(Session["IdUsuario"]));
                ViewBag.Menus = permisos;
            }

            PlataformaEntities server = new PlataformaEntities();
            List<CursoActions> lista = server.Curso.Take(5).Select(a => new CursoActions()
            {
                idusuario = a.IdUsuario,
                idcurso = a.Id,
                titulocurso = a.Titulo,
                categoriacurso = a.Categoria,
                descripcioncurso = a.Descripcion,
            }).OrderByDescending(a => a.idcurso).ToList();
            ViewBag.info = lista;

            List<UsuarioActions> listaautor = server.Usuario.Take(5).Select(a => new UsuarioActions()
            {
                idusuario = a.Id,
                nombresusuario = a.Nombres,
                appaternousuario = a.ApPaterno,
                apmaternousuario = a.ApMaterno,
            }).ToList();
            ViewBag.autor = listaautor;
            return View();
        }


        public ActionResult About()
        {
            if (Request.IsAuthenticated)
            {
                AdminActions contexto = new AdminActions();
                List<PermisosDeMenu> permisos = new List<PermisosDeMenu>();
                if (Session["IdUsuario"] != null)
                    permisos = contexto.getPermisos(Convert.ToInt32(Session["IdUsuario"]));
                ViewBag.Menus = permisos;
            }
            ViewBag.Message = "Página de descripción de la aplicación.";

            return View();
        }

        public ActionResult Contact()
        {
            if (Request.IsAuthenticated)
            {
                AdminActions contexto = new AdminActions();
                List<PermisosDeMenu> permisos = new List<PermisosDeMenu>();
                if (Session["IdUsuario"] != null)
                    permisos = contexto.getPermisos(Convert.ToInt32(Session["IdUsuario"]));
                ViewBag.Menus = permisos;
            }
            ViewBag.Message = "Página de contacto.";

            return View();
        }
        public ActionResult LoginUsuario()
        {
            if (Request.IsAuthenticated)
            {
                AdminActions contexto = new AdminActions();
                List<PermisosDeMenu> permisos = new List<PermisosDeMenu>();
                if (Session["IdUsuario"] != null)
                    permisos = contexto.getPermisos(Convert.ToInt32(Session["IdUsuario"]));
                ViewBag.Menus = permisos;
            }
            return View();
        }

        //---------------CHAT PRINCICPAL---------------//
        //[Authorize(Roles = "VerChat")]
        public ActionResult Principal(int id)
        {
            ViewBag.id = Session["IdUsuario"];
 
            ViewBag.idSesion = id;
            return View();
        }

        //---------------ENVIAR MENSAJE---------------//
        //[Authorize(Roles = "VerChat")]
        [HttpPost]
        public JsonResult Enviar(Mensaje msn1)
        {
            if (Session["IdUsuario"] == null)
                return Json(new { data = false });
            msn1.IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
            //msn1.IdSesion = 1;
            msn1.Fecha = DateTime.Now;
            msn1.Mes = (DateTime.Now.Month).ToString();
            msn1.Dia = (DateTime.Now.Day).ToString();
            msn1.Hora = (DateTime.Now.Hour).ToString();
            msn1.Minuto = (DateTime.Now.Minute).ToString();
            msn1.Segundo = (DateTime.Now.Second).ToString();
            UsuarioActions contexto = new UsuarioActions();

            if (contexto.enviarMensaje(msn1))
            {

                return Json(new { data = true });
            }
            ViewBag.horachat = DateTime.Now.Hour;
            return Json(new { data = false });
        }

        //---------------RESCATAR MENSAJE---------------//
        //[Authorize(Roles = "VerChat")]
        [HttpPost]
        public JsonResult getMensajes(int id)
        {
            //int idSes = 1;
            //int idsesion=id;
            MensajeActions contexto = new MensajeActions();
            List<Mensaje> listaMensajes = contexto.getMensajes(id);
            List<MensajesView> listaMostrar = new List<MensajesView>();
            foreach (var item in listaMensajes)
            {
                MensajesView ins = new MensajesView()
                {
                    nick = item.Usuario.Nickname,
                    mmensaje = item.Msn,
  
                    mes = (DateTime.Now.Month) - Convert.ToInt32(item.Mes),
                    dia = (DateTime.Now.Day - Convert.ToInt32(item.Dia)),
                    hora = (DateTime.Now.Hour - Convert.ToInt32(item.Hora)),
                    minutos = (DateTime.Now.Minute - Convert.ToInt32(item.Minuto)),
                    segundos = (DateTime.Now.Second - Convert.ToInt32(item.Segundo))
                };
                listaMostrar.Add(ins);
            }
            return Json(new { lista = listaMostrar });
        }


        //---------------OBTENER USUARIOS---------------//
        //[Authorize(Roles = "VerChat")]
        public JsonResult getUsuarios()
        {
            UsuarioActions contexto = new UsuarioActions();
            List<Usuario> lista = contexto.getUsuarioConectado();
            List<string> nicks = new List<string>();
            foreach (var item in lista)
            {
                nicks.Add(item.Nickname);
            }
            return Json(new { lista = nicks });
        }
        //------------COMPROBAR NOMBRE DE USUARIO//
        public bool comprobarelnombredeusuario(Usuario user)
        {
            PlataformaEntities server = new PlataformaEntities();
            if (server.Usuario.Where(model => model.Nickname == user.Nickname).Count() > 0)
            {
                return false;
            }
            return true;
        }
    }
}
