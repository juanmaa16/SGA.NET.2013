using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class MateriaLogic : BusinessLogic
    {
        
        MateriaAdapter mData;

        public MateriaLogic()
        {
            this.mData = new MateriaAdapter();
        }

        public MateriaAdapter MateriaData
        {
            get;
            set;
        }

        public List<Materia> GetAll()
        {
            return mData.GetAll();
        }

        public Materia GetOne(int ID)
        {
            return mData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            mData.Delete(ID);
        }

        public void Save(Materia materia)
        {
            mData.Save(materia);
        }
    }
}
