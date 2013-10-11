using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class EspecialidadLogic: BusinessLogic
    {
         EspecialidadAdapter eData;

        public EspecialidadLogic()
        {
           this.eData = new EspecialidadAdapter();
        }

        public EspecialidadAdapter EspecialidadData
        {get;set;}

        public List<Especialidad> GetAll()
        {
            return  eData.GetAll();
        }

        public Especialidad GetOne(int ID)
        {
            return eData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            eData.Delete(ID);
        }

        public void Save(Especialidad especialidad)
        {
            eData.Save(especialidad);
        }
    }
}
