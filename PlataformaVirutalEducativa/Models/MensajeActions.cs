using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class MensajeActions
    {
        PlataformaEntities server;
        public int idmensaje { set; get; }
        public int idusuario { set; get; }
        public string msnmensaje { set; get; }
        public DateTime fechamensaje { set; get; }
        public DateTime mesmensaje { set; get; }
        public DateTime diamensaje { set; get; }
        public DateTime horamensaje { set; get; }
        public DateTime minutomensaje { set; get; }
        public DateTime segundomensaje { set; get; }

        public MensajeActions()
        {
            server = new PlataformaEntities();
        }
        public List<Mensaje> getMensajes(int id)
        {
            return server.Mensaje.Where(a => a.IdSesion == id).Take(10).OrderByDescending(a => a.Id).ToList();
        }
    }
}