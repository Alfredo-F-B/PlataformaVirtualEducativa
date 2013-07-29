using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class ComentarioActions
    {
        PlataformaEntities server;
        public int idcomentario { set; get; }
        public int idusuario { set; get; }
        public int idcurso { set; get; }
        public string comencomentario { set; get; }
        public DateTime fechacomentario { set; get; }
        public DateTime mescomentario { set; get; }
        public DateTime diacomentario { set; get; }
        public DateTime horacomentario { set; get; }
        public DateTime minutocomentario { set; get; }
        public DateTime segundocomentario { set; get; }

        public ComentarioActions()
        {
            server = new PlataformaEntities();
        }
        public List<Comentario> getComentario() 
        {
            return server.Comentario.Take(20).OrderByDescending(a=>a.Id).ToList();
        }
    }
}