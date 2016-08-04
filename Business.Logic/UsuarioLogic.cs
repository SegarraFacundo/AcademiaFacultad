using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {

        private UsuarioAdapter UsuarioData;

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public Usuario GetOne(int id)
        {
            Usuario usuario = UsuarioData.GetOne(id);
            return usuario;
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = UsuarioData.GetAll();
            return usuarios;
        }

        public void Save(Usuario u)
        {
            UsuarioData.Save(u);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }
    }
}
