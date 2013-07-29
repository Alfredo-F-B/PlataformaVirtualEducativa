using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class Login 
    {
        public string nick { set; get; }
        public string password { set; get; }
        public string repass { set; get; }
    }
    public class msnSend
    {
        public string id { set; get; }
        public string msn { set; get; }
    }
    public class MensajesView {
        public string nick { set; get; }
        public string mmensaje { set; get; }
        public int idse { set; get; }
        public string fecha { set; get; }
        public int mes { set; get; }
        public int dia { set; get; }
        public int hora { set; get; }
        public int minutos { set; get; }
        public int segundos { set; get; }
    }



    public class comenSend
    {
        public string id { set; get; }
        public string comen { set; get; }
    }
    public class ComentarioView
    {
        public string nick { set; get; }
        public string mmensaje { set; get; }
        public string fecha { set; get; }
        public int mes { set; get; }
        public int dia { set; get; }
        public int hora { set; get; }
        public int minutos { set; get; }
        public int segundos { set; get; }
    }
    /*public class PrincipalModel
    {
        public List<usuario> listausuarios { set; get; }
        public List<mensaje> listaMensajes { set; get; }
        public mensaje mensaje { set; get; }
    }*/
}