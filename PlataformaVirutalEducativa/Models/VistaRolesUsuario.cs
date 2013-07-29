using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class VistaRolesUsuario
    {
        public UserProfile user { set; get; }
        public  List<webpages_Roles> rolesUser { set; get; }

    }
}