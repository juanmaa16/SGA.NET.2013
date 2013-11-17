using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class ModuloLogic: BusinessLogic
    {
        ModuloAdapter mData;

        public ModuloLogic()
        {
            this.mData = new ModuloAdapter();
        }

        public ModuloAdapter ModuloData
        {
            get;
            set;
        }

        public List<Modulo> GetAll()
        {
            return mData.GetAll();
        }

        public Modulo GetOne(int ID)
        {
            return mData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            mData.Delete(ID);
        }

        public void Save(Modulo modulo)
        {
            mData.Save(modulo);
        }
    }
}


