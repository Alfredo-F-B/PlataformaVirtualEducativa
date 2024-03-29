//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlataformaVirutalEducativa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comentario
    {
        public Comentario()
        {
            this.Respuesta = new HashSet<Respuesta>();
        }
    
        public int Id { get; set; }
        public int IdSesion { get; set; }
        public int IdUsuario { get; set; }
        public string Comentario1 { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Mes { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
        public string Minuto { get; set; }
        public string Segundo { get; set; }
    
        public virtual Sesion Sesion { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
