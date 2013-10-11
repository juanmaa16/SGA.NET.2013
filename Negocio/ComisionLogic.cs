using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class ComisionLogic: BusinessLogic
    {
        ComisionAdapter cData;

        public ComisionLogic()
        {
           this.cData = new ComisionAdapter();
        }

        public ComisionAdapter ComisionData
        {get;set;}

        public List<Comision> GetAll()
        {
            return  cData.GetAll();
        }

        public Comision GetOne(int ID)
        {
            return cData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            cData.Delete(ID);
        }

        public void Save(Comision comision)
        {
            cData.Save(comision);
        }
    }
}
