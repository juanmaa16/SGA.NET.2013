using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class PlanLogic : BusinessLogic
    {
        PlanAdapter pData;

        public PlanLogic()
        {
            this.pData = new PlanAdapter();
        }

        public PlanAdapter PlanData
        {
            get;
            set;
        }

        public List<Plan> GetAll()
        {
            return pData.GetAll();
        }

        public Plan GetOne(int ID)
        {
            return pData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            pData.Delete(ID);
        }

        public void Save(Plan plan)
        {
            pData.Save(plan);
        }
    }
}
