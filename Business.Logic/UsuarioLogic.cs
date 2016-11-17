using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;
using Util.CustomException;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {

        private UsuarioAdapter usuarioData;
        private PermisoAdapter pa;

        public UsuarioLogic()
        {
            this.pa = new PermisoAdapter();
            this.usuarioData = new UsuarioAdapter();
        }

        public Usuario GetOne(int id)
        {
            try
            {
                Usuario usuario = this.usuarioData.GetOne(id);
                usuario.Permisos = this.pa.GetPorIdUsuario(usuario.Id);

                return usuario;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex);
            }
        }

        public List<Usuario> GetAll()
        {
            try
            {
                List<Usuario> usuarios = this.usuarioData.GetAll();
                return usuarios;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex);
            }
        }

        public void Save(Usuario u)
        {
            this.usuarioData.Save(u);
        }       

        public Usuario LogIn(string user, string pass)
        {
            try
            {
                List<Usuario> listaUsuarios = new List<Usuario>();
                listaUsuarios = usuarioData.GetAll();
                foreach (Usuario u in listaUsuarios)
                {
                    if (u.Clave == pass && u.NombreUsuario == user)
                    {
                        if (u.Habilitado)
                        {
                            u.Permisos = this.pa.GetPorIdUsuario(u.Id);
                            return u;
                        }
                        
                    }
                }
                
                return null;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex);
            }
        }

        public bool VerificarClaves(Usuario user, string passNueva)
        {
            bool estado = true;

            //Verificamos que no sea la misma
            if (user.Clave == passNueva)
            {
                return false;
            }
            //Verificamos que mayor a 8 caracteres
            if (passNueva.Length < 8)
            {
                return false;
            }
            return estado;
        }
    }
}
