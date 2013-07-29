using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class CursoActions
    {
            public int idcurso { set; get; }
            public int idusuario { set; get; }
            public string titulocurso { set; get; }
            public string categoriacurso { set; get; }
            public string descripcioncurso { set; get; }
            public DateTime iniciocurso { set; get; }
            public int duracioncurso { set; get; }
            public DateTime fechacurso { set; get; }   
            public int cupocurso { set; get; }

            PlataformaEntities server;
            public CursoActions()
            {
                server = new PlataformaEntities();
            }

            public List<Curso> getCursos()
            {
                return server.Curso.ToList();
            }

            public List<Sesion> getSesiones(int idCurso)
            {
                return server.Sesion.Where(a => a.IdCurso == idCurso).ToList();
            }

    }    
}