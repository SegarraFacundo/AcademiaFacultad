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

        public UsuarioLogic()
        {
            this.usuarioData = new UsuarioAdapter();
        }

        public Usuario GetOne(int id)
        {
            try
            {
                Usuario usuario = this.usuarioData.GetOne(id);
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
                Usuario u = this.usuarioData.LogIn(user, pass);
                return u;
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
    }
}
