using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlataformaVirutalEducativa.Models
{
    public class AdminActions
    {
        private PlataformaEntities server;
        UsersContext userserver;
        public AdminActions() 
        {
            server = new PlataformaEntities();
            userserver = new UsersContext();
        }

        /*-------------------CREA ROLES------------------*/
        public bool InsertarRol(webpages_Roles roles)
        {
            server.webpages_Roles.Add(roles);
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

        /*----------------LISTA A LOS USUARIOS-----------------------*/
        public List<UserProfile> getUsers()
        {
            return userserver.UserProfiles.ToList();
        }
        /*----------------LISTA LOS ROLES-----------------------*/
        public List<webpages_Roles> getRoles()
        {
            return server.webpages_Roles.ToList();
        }

        /*----------------LISTA LOS ROLES QUE TIENE EL USUARIO-----------------------*/
        public List<webpages_UsersInRoles> getRolesQueTieneElUsuario(int idUser)
        {
            return server.webpages_UsersInRoles.Where(a=>a.UserId==idUser).ToList();
        }
        /*----------------Inserta usuarios en User In Roles-----------------------*/
        public bool InsertarUsuario_Rol(webpages_UsersInRoles roles_usuario)
        {
            server.webpages_UsersInRoles.Add(roles_usuario);
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


        internal UserProfile getUser(int id)
        {
            return userserver.UserProfiles.Where(a => a.UserId == id).First();
        }

        /*-------------------------OBTENER PERMISOS----------------------*/
        public List<PermisosDeMenu> getPermisos(int idUs) 
        {
            List<PermisosDeMenu> resultado = server.webpages_UsersInRoles
                .Where(a => a.UserId == idUs)
                .Select(b => new PermisosDeMenu()
                {
                    idRol = b.RoleId,
                    label = b.webpages_Roles.RoleName
                }).ToList();
            return resultado;
        }











        public List<Usuario> getUsuario()
        {
            return server.Usuario.ToList();
        }

        internal UserProfile getUsers(int id)
        {
            return userserver.UserProfiles.Where(a => a.UserId == id).First();
        }

        public Usuario getUsuarios(int id)
        {
            return server.Usuario.Where(a => a.Id == id).FirstOrDefault();
        }

        internal UserProfile getUsuario(string p)
        {
            return userserver.UserProfiles.Where(a => a.UserName == p).FirstOrDefault();
        }


        public void guardarFile(string r, string n, int idus)
        {
            Material ss = new Material()
            {
                Id = idus,
                ////fecha_reg_mat=DateTime.Now,
                //fecha_reg_mat=DateTime.Now,
                UrlAbs = r,
                UrlWeb = "http://localhost:5889" + n
            };

            server.Material.Add(ss);
            server.SaveChanges();
        }
        internal List<Material> getFiles(int p)
        {
            return server.Material.Where(a => a.IdUsuario == p).ToList();
        }

        /*internal usuario getUsuarios(string p)
        {
            return server.usuario.Where(a => a.nombres == p).FirstOrDefault();
            //return userserver.UserProfiles.Where(a => a.UserName == p).FirstOrDefault();
            //throw new NotImplementedException();
        }*/
        public int getid(LoginModel login)
        {
            int id = userserver.UserProfiles.Where(a => a.UserName == login.UserName).First().UserId;
            return id;
        }

        internal int getID(LoginModel model)
        {
            return userserver.UserProfiles.Where(a => a.UserName == model.UserName).First().UserId;

        }
    }
}