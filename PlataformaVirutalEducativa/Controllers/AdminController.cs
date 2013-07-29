using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlataformaVirutalEducativa.Models;

namespace PlataformaVirutalEducativa.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        // ------------------------CREAR ROLES----------------------
        //[Authorize(Roles = "CrearRol")]
        public ActionResult CrearRoles()
        {
            return View();
        }



        //[Authorize(Roles = "CrearRol")]
        [HttpPost]
        public ActionResult CrearRoles(webpages_Roles roles)
        {
            AdminActions contexto = new AdminActions();
            if (contexto.InsertarRol(roles)) 
            {
                return View("RolInsertado");
            };
            return View();
        }



        // ------------------------MOSTRAR ASIGNACION DE ROLES DEL USUARIO----------------------
        //[Authorize(Roles = "AsignarRol")]
        public ActionResult AsignarRolesUsuario()
        {
            AdminActions contexto = new AdminActions();
            List<UserProfile> Usuarios= contexto.getUsers();
            return View(Usuarios);
        }
        // ------------------------ASIGNAR ROLES----------------------
        //[Authorize(Roles = "AsignarRol")]
        public ActionResult AsignarRol(int id)
        {
            AdminActions contexto = new AdminActions();
            UserProfile usuario=contexto.getUser(id);
            List<webpages_Roles> lista = contexto.getRoles();
            VistaRolesUsuario modelovista = new VistaRolesUsuario();
            modelovista.user = usuario;
            modelovista.rolesUser = lista;

            PlataformaEntities server = new PlataformaEntities();
            List<RolesActions> ListaRolAsignado = server.webpages_UsersInRoles.Select(a => new RolesActions()
            {
                usersId=a.UserId,
                rolesId=a.RoleId
            }).ToList();
            ViewBag.rol = ListaRolAsignado;

            List<RolesActions> ListaRolNoAsignado = server.webpages_Roles.Select(a => new RolesActions()
            {
                rolname=a.RoleName,
                idrolname = a.RoleId
            }).OrderByDescending(b=>b.idrolname).ToList();
            ViewBag.rolname = ListaRolNoAsignado;

            return View(modelovista);

        }
        // ------------------------AGREGAR ROL----------------------
        //[Authorize(Roles = "AsignarRol")]
        public ActionResult AgregarRol(string id)
        {
            int idUs = Convert.ToInt32(id.Split('|')[0]);
            int idRol = Convert.ToInt32(id.Split('|')[1]);
            webpages_UsersInRoles rolAsignado = new webpages_UsersInRoles();
            rolAsignado.UserId = idUs;
            rolAsignado.RoleId = idRol;
            AdminActions contexto = new AdminActions();
            if (contexto.InsertarUsuario_Rol(rolAsignado))
            {
                return View("ExitoAsignacion");
            };
            return View();
        }
    }
}
