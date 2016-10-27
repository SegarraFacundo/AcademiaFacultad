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
    public class ModuloUsuarioLogic:BusinessLogic
    {
        private ModuloUsuarioAdapter moduloUsuarioData;

        public ModuloUsuarioLogic()
        {
            this.moduloUsuarioData = new ModuloUsuarioAdapter();
        }

        public void getPermisosUsuario(int idUsuario)
        {
            try
            {
                moduloUsuarioData = new ModuloUsuarioAdapter();
                List<ModuloUsuario> listaPermisos = moduloUsuarioData.getPermisosUsuario(idUsuario);
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
