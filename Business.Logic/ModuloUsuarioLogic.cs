using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloUsuarioLogic:BusinessLogic
    {
        private ModuloUsuarioAdapter moduloUsuarioData;

        public void getPermisosUsuario(int idUsuario)
        {
            moduloUsuarioData = new ModuloUsuarioAdapter();
            List<ModuloUsuario> listaPermisos = moduloUsuarioData.getPermisosUsuario(idUsuario);
            foreach (ModuloUsuario mu in listaPermisos) 
            {
                
            }
            
        }
    }
}
