using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using Util.CustomException;

namespace Business.Logic
{
    public class AdministradorLogic : BusinessLogic
    {

        private AdministradorAdapter administradorData;

        public AdministradorLogic()
        {
            this.administradorData = new AdministradorAdapter();
        }

        public Administrador GetOne(int ID)
        {
            try
            {
                Administrador a = this.administradorData.GetOne(ID);
                return a;
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

        public List<Administrador> GetAll()
        {
            try
            {
                List<Administrador> ListaAdministrador = this.administradorData.GetAll();
                return ListaAdministrador;
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

        public void Delete(int ID)
        {
            try
            {
                this.administradorData.Delete(ID);
            }
            catch (DeleteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex);
            }
        }

        public void Save(Administrador a)
        {
            this.administradorData.Save(a);
        }

        public int obtenerProximoLegajo()
        {
            try
            {
                int legajo = this.administradorData.obtenerUltimoLegajo("administrador");
                if (legajo.Equals(0))
                    throw new NotFoundException("legajo");
                legajo += 1;
                return legajo;
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
