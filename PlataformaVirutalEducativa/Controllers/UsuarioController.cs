using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlataformaVirutalEducativa.Models;
namespace PlataformaVirutalEducativa.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {

            return View();
        }

        public ViewResult MostrarUsuario()
        {
            PlataformaEntities server = new PlataformaEntities();
            List<UsuarioActions> lista = server.Usuario.Select(a => new UsuarioActions()
            {
                nicknameusuario = a.Nickname,
                estadousuario = a.Estado,
                ciusuario = a.CI,
                appaternousuario = a.ApPaterno,
                apmaternousuario = a.ApMaterno,
                nombresusuario = a.Nombres,
                sexousuario = a.Sexo,
                fechanacimientousuario = a.FechaNacimiento,
                direccionusuario = a.Direccion,
                telefonousuario = a.Telefono,
                celularusuario = a.Celular
            }).ToList();
            ViewBag.info = lista;
            return View();
        }   
    }
}
