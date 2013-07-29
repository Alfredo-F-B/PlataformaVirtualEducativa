using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class RolesActions
    {
        public int usersId { set; get; }
        public int rolesId { set; get; }

        public string rolname { set; get; }
        public int idrolname { set; get; }


        PlataformaEntities server;
        public RolesActions()
        {
            server = new PlataformaEntities();
        }
    }
}