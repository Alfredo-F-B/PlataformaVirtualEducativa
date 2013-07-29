using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlataformaVirutalEducativa.Models;

namespace PlataformaVirutalEducativa.Models
{
    public class UsuarioActions
    {
        public int idusuario { set; get; }
        public int iduserroles { set; get; }
        public string nicknameusuario { set; get; }
        public string passwordusuario { set; get; }
        public string repasswordusuario { set; get; }
        public string estadousuario { set; get; }
        public string ciusuario { set; get; }
        public string appaternousuario { set; get; }
        public string apmaternousuario { set; get; }
        public string nombresusuario { set; get; }
        public string sexousuario { set; get; }
        public DateTime fechanacimientousuario { set; get; }
        public string direccionusuario { set; get; }
        public string telefonousuario { set; get; }
        public string celularusuario { set; get; }
        public DateTime fecharegistrousuario { set; get; }

        PlataformaEntities server;
        public UsuarioActions()
        {
            server = new PlataformaEntities();
        }
        public bool registrar(Usuario user)
        {
            try
            {
                server.Usuario.Add(user);
                server.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool comprobarelnombredeusuario(Usuario user)
        {
            if (server.Usuario.Where(model => model.Nickname == user.Nickname).Count() > 0)
            {
                return false;
            }
            return true;
        }
        public Usuario getUsuario(int id)
        {
            return server.Usuario.Where(a => a.Id == id).FirstOrDefault();
        }
        public bool VerificarLogin(Login datos)
        {
            int i = server.Usuario.Where(
                a => a.Nickname == datos.nick &&
                a.Password == datos.password).Count();
            if (i == 0)
                return false;
            return true;
        }


        public Usuario getUsuario(string nick)
        {
            return server.Usuario.Where(a => a.Nickname == nick).First();
        }


        public Usuario getUsuario(Login datos)
        {
            return server.Usuario.Where(a => a.Nickname == datos.nick && a.Password == datos.password).First();

        }
        internal bool ActualizarEstado(string p, Login datos)
        {
            Usuario user = getUsuario(datos);
            user.Estado = p;
            try
            {
                server.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //-------------------------falta comparar con el id de la sesion-------------------------

        public List<Usuario> getUsuarioConectado()
        {
            return server.Usuario.Where(a =>
                a.Estado == "Conectado" ).ToList();
            //return server.Mensaje.Where(a => a.IdSesion == id).Select(a => a.Usuario).ToList();
        }
        public List<Mensaje> getMensajes(int id)
        {
            return server.Mensaje.Where(a => a.IdSesion == id).Take(10).OrderByDescending(a => a.Id).ToList();
        }
        public bool enviarMensaje(Mensaje msn)
        {
            server.Mensaje.Add(msn);
            try
            {
                server.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool enviarComentario(Comentario msn)
        {
            server.Comentario.Add(msn);
            try
            {
                server.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        internal bool ActualizarEstado(string p, int id)
        {
            Usuario user = getUsuario(id);
            user.Estado = p;
            try
            {
                server.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //public List<Curso> getCurso()
        //{
        //    return server.Curso.ToList();
        //}

    }
}