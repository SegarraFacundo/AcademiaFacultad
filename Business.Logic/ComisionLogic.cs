﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using Util.CustomException;
using Util;


namespace Business.Logic
{
    public class ComisionLogic
    {
         private ComisionAdapter ComisionData;

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public Comision GetOne(int ID)
        {
            try
            {
                Comision com = ComisionData.GetOne(ID);
                return com;
            }
            catch ( NotFoundException ex )
            {
                throw ex;
            }
            catch ( Exception ex )
            {
                throw new CustomException(ex);
            }

        }

        public void Save(Comision c)
        {
            ComisionData.Save(c);
        }

        public List<Comision> GetAll()
        {
            try
            {
                List<Comision> comisiones = this.ComisionData.GetAll();
                return comisiones;
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
        public List<Comision> GetComisionPorPlan(int idPlan)
        {
            try
            {
                List<Comision> comisiones = this.ComisionData.GetAll();
                List<Comision> comsionesConPlan = new List<Comision>();
                foreach (Comision c in comisiones)
                {
                    if (c.IdPlan == idPlan)
                    {
                        comsionesConPlan.Add(c);
                    }
                }
                return comsionesConPlan;
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

        public bool ValidarDelete(int idComision)
        {
            CursoAdapter ca = new CursoAdapter();
            List<Curso> listaCursos = ca.GetAll();
            foreach (Curso c in listaCursos)
            {
                if (c.IdComision == idComision) { return false; }
            }
            return true;
        }
    }

}
