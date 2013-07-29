using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class ModelSesion
    {
        public string titulo { set; get; }
        [Required(ErrorMessage = "introduzaca el titulo")]
        public string contenido { set; get; }
        [Required(ErrorMessage = "introduzaca el contenido")]
        public TimeSpan hora_inicio { set; get; }
        [Required(ErrorMessage = "introduzca la hora inicial")]
        public TimeSpan hora_final { set; get; }
        [Required(ErrorMessage = "introduzaca la hora final")]
        public DateTime fecha { set; get; }
        
    }
}