using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlataformaVirutalEducativa.Models;

namespace PlataformaVirutalEducativa.Controllers
{
    public class CursoController : Controller
    {
        //
        // GET: /Curso/

        public ActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "CrearCurso")]
        public ActionResult RegistrarCurso()
        {
            return View();
        }
        //[Authorize(Roles = "CrearCurso")]
        [HttpPost]
        public ActionResult RegistrarCurso(Curso cur)
        {
            PlataformaEntities server = new PlataformaEntities();
            cur.IdUsuario=Convert.ToInt32(Session["IdUsuario"]);
            cur.Fecha = DateTime.Now;
            server.Curso.Add(cur);
            server.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        //[Authorize(Roles = "VerCurso")]
        public ActionResult MostrarCurso(string id)
        {

            ViewBag.id = Session["IdUsuario"];

            int idCur = Convert.ToInt32(id[0])-48;
            ViewBag.idcurso = idCur;
            ViewBag.idusuario = idCur;
            PlataformaEntities server = new PlataformaEntities();
            List<CursoActions> lista = server.Curso.Select(a => new CursoActions()
            {
                idusuario=a.IdUsuario,
                idcurso=a.Id,
                titulocurso = a.Titulo,
                categoriacurso = a.Categoria,
                descripcioncurso = a.Descripcion,
                iniciocurso = a.Inicio,
                duracioncurso = a.Duracion,
                cupocurso = a.Cupo,
                fechacurso = a.Fecha,
            }).ToList();
            ViewBag.info2 = lista;

            List<UsuarioActions> listaautor = server.Usuario.Select(a => new UsuarioActions()
            {
                idusuario = a.Id,
                nombresusuario = a.Nombres,
                appaternousuario = a.ApPaterno,
                apmaternousuario = a.ApMaterno,
            }).ToList();
            ViewBag.autor2 = listaautor;
            return View();
        }

        //[Authorize(Roles = "VerCurso")]
        public ActionResult Precursos(Usuario user)
        {
            PlataformaEntities server = new PlataformaEntities();
            List<CursoActions> lista = server.Curso.Select(a => new CursoActions()
            {
                idusuario = a.IdUsuario,
                idcurso=a.Id,
                titulocurso = a.Titulo,
                categoriacurso = a.Categoria,
                descripcioncurso = a.Descripcion,
            }).ToList();
            ViewBag.info = lista;

            List<UsuarioActions> listaautor = server.Usuario.Select(a => new UsuarioActions()
            {
                idusuario=a.Id,
                nombresusuario = a.Nombres,
                appaternousuario = a.ApPaterno,
                apmaternousuario = a.ApMaterno,
            }).ToList();
            ViewBag.autor = listaautor;
            return View();
        }


        public ActionResult MisCursos(Usuario user,Inscripcion ins)
        {
            PlataformaEntities server = new PlataformaEntities();
            List<CursoActions> lista = server.Curso.Select(a => new CursoActions()
            {
                idusuario = a.IdUsuario,
                idcurso = a.Id,
                titulocurso = a.Titulo,
                categoriacurso = a.Categoria,
            }).ToList();
            ViewBag.info = lista;


            if (Session["IdUsuario"] == null)
            {
                ViewBag.id = 0;
            }
            else
            {
                
                ViewBag.id = Session["IdUsuario"];
            }
           
            List<InscripcionActions> listainscripcion = server.Inscripcion.Select(a => new InscripcionActions()
            {
                idinscripcion = a.Id,
                idcurso=a.IdCurso,
                idusuario=a.IdUsuario
            }).ToList();
            ViewBag.inscripcion = listainscripcion;
            return View();
        }


        public ActionResult CrearSala()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearSala(Sesion ses,string id)
        {
            PlataformaEntities server = new PlataformaEntities();
            int idCur = Convert.ToInt32(id[0])-48;

            ses.IdCurso = idCur;
            ses.Fecha = DateTime.Now;

            server.Sesion.Add(ses);
            server.SaveChanges();
            return View();
        }

        public ActionResult Salas(string id)
        {
            PlataformaEntities server = new PlataformaEntities();
            int idCur = Convert.ToInt32(id[0]) - 48;
            ViewBag.idcurso = idCur;
            //ViewBag.idcurso = id;
            List<SesionActions> listainscripcion = server.Sesion.Select(a => new SesionActions()
            {
                idsesion = a.Id,
                idcurso = a.IdCurso,
                Nombre = a.NombreSesion
            }).ToList();
            ViewBag.sesion = listainscripcion;
            return View();
        }








        //---------------mostrar es el comentario PRINCICPAL---------------//


        //---------------ENVIAR COMENTARIO---------------//
        [Authorize(Roles = "VerChat")]
        [HttpPost]
        public JsonResult Enviar(Comentario com1,string id)
        {
            //int idCur = Convert.ToInt32(id[0]) - 48;
            if (Session["IdUsuario"] == null)
                return Json(new { data = false });

            com1.IdUsuario = Convert.ToInt32(Session["IdUsuario"]);

            //com1.IdCurso = 1;

            com1.Fecha = DateTime.Now;
            com1.Mes = (DateTime.Now.Month).ToString();
            com1.Dia = (DateTime.Now.Day).ToString();
            com1.Hora = (DateTime.Now.Hour).ToString();
            com1.Minuto = (DateTime.Now.Minute).ToString();
            com1.Segundo = (DateTime.Now.Second).ToString();
            UsuarioActions contexto = new UsuarioActions();

            if (contexto.enviarComentario(com1))
            {

                return Json(new { data = true });
            }
            ViewBag.horachat = DateTime.Now.Hour;
            return Json(new { data = false });
        }

        //---------------RESCATAR MENSAJE---------------//
        [Authorize(Roles = "VerChat")]
        [HttpPost]
        public JsonResult getComentario()
        {
            ComentarioActions contexto = new ComentarioActions();
            List<Comentario> listaComentario = contexto.getComentario();
            List<ComentarioView> listaMostrar = new List<ComentarioView>();
            foreach (var item in listaComentario)
            {
                ComentarioView ins = new ComentarioView()
                {
                    nick = item.Usuario.Nickname,
                    mmensaje = item.Comentario1,
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
        //public JsonResult getUsuarios()
        //{
        //    UsuarioActions contexto = new UsuarioActions();
        //    List<Usuario> lista = contexto.getUsuarioConectado();
        //    List<string> nicks = new List<string>();
        //    foreach (var item in lista)
        //    {
        //        nicks.Add(item.Nickname);
        //    }
        //    return Json(new { lista = nicks });
        //}
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
