using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using a = System.IO;
using System.IO.Compression;
using WebMatrix.WebData;
using PlataformaVirutalEducativa.Models;
namespace PlataformaVirutalEducativa.Controllers
{
    public class UploadMaterialController : Controller
    {
        //
        // GET: /UploadMaterial/

        public ActionResult Index()
        {
            return View();
        }
        /*
         Subir archivos
         */
        [HttpPost]
        public JsonResult SaveFiles()
        {
            HttpFileCollectionBase files = Request.Files;
            string path = Server.MapPath("~/archivos/");
            string nombres_de_arcnivos = "";
            string respuesta = "";
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].ContentLength > 0)
                {
                    string[] archivoenpartes = files[i].FileName.Split('.');
                    if (archivoenpartes.Length == 0)
                    {
                        respuesta = "false";
                        return Json(data: respuesta);
                    }
                    nombres_de_arcnivos += files[i].FileName;
                    string extension = archivoenpartes[1];
                    string nombredearchivo = archivoenpartes[0];
                    string name = DateTime.Now.GetHashCode().ToString();
                    files[i].SaveAs(path + name + "." + extension);
                    respuesta += "/archivos/" + name + "." + extension;
                }
                else
                {
                    respuesta = "false";
                }
            }
            AdminActions ad = new AdminActions();
            //int id = Convert.ToInt32(Session["idus"]);
            int id1 = WebSecurity.CurrentUserId;
            ad.guardarFile(respuesta, nombres_de_arcnivos, id1);

            return Json(data: new ResultUploadMaterial() { filename = nombres_de_arcnivos, fileroute = respuesta });
        }
        public ActionResult getArchivos()
        {
            AdminActions contexto = new AdminActions();
            Usuario user = contexto.getUsuarios(WebSecurity.CurrentUserId);
            List<Material> lista;
            if (user != null)
                lista = contexto.getFiles(user.Id);
            else
                lista = new List<Material>();
            return View(lista);
        }
        public JsonResult Descargartodo()
        {
            AdminActions contexto = new AdminActions();
            Usuario user = contexto.getUsuarios(WebSecurity.CurrentUserId);
            List<Material> lista = contexto.getFiles(user.Id);
            //creamos la carpeta prov.
            a.Directory.CreateDirectory(Server.MapPath("/archivos/descargas") + @"\" + user.Nombres + @"\");
            foreach (Material item in lista)
            {
                string nombre = item.UrlAbs.Split('/')[2];
                // a.File.Copy(Server.MapPath(item.urlAbs), Server.MapPath("/archivos/descargas"+user.nombres)+"/"+nombre);
                a.File.Copy(Server.MapPath(item.UrlAbs), Server.MapPath("/archivos/descargas/" + user.Nombres) + "/" + nombre);
            }
            ZipFile.CreateFromDirectory(Server.MapPath("/archivos/descargas") + @"\" + user.Nombres + @"\", Server.MapPath("/archivos/descargas") + @"\" + user.Nombres + ".zip");
            string link = "http://localhost:1670/archivos/descargas/" + user.Nombres + ".zip";
            return Json(new { link = link });
        }
        public ViewResult mostrarusuariosarchivos()
        {
            AdminActions contexto = new AdminActions();
            List<Usuario> usuarios = contexto.getUsuario();
            return View(usuarios);
        }
    }
}