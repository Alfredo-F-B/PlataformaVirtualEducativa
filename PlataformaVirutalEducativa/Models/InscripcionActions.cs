using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlataformaVirutalEducativa.Models;

namespace PlataformaVirutalEducativa.Models
{
    public class InscripcionActions
    {
        PlataformaEntities server;
        UsersContext userserver;
        public InscripcionActions() 
        {
            server = new PlataformaEntities();
            userserver = new UsersContext();
        }

        public bool InsertarInscripcion(Inscripcion ins)
        {
            server.Inscripcion.Add(ins);
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

        public int idinscripcion { set; get; }
        public int idusuario { set; get; }
        public int idcurso { set; get; }
    }
}