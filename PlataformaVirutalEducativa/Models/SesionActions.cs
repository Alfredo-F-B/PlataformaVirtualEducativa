using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class SesionActions
    {
        PlataformaEntities server;
        UsersContext userserver;
        public SesionActions() 
        {
            server = new PlataformaEntities();
            userserver = new UsersContext();
        }

        public int idsesion { set; get; }
        public int idcurso { set; get; }
        public string Nombre { set; get; }
    }
}