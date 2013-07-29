using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class RespuestaActions
    {
        public int idrespuesta { set; get; }
        public int idcomentario { set; get; }
        public int idpuntaje { set; get; }
        public string textorespuesta { set; get; }
        public DateTime fecharespuesta { set; get; }
    }
}