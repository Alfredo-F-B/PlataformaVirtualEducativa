using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class MaterialActions
    {
        public int idmaterial { set; get; }
        public int idcurso { set; get; }
        public string nombrematerial { set; get; }
        public string descripcionmaterial { set; get; }
        public DateTime fechamaterial { set; get; }

    }
}