using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        ModuloUsuarioAdapter mData;

        public ModuloUsuarioLogic()
        {
            this.mData = new ModuloUsuarioAdapter();
        }

        public ModuloUsuarioAdapter ModuloData
        {
            get;
            set;
        }

        public List<ModuloUsuario> GetAll()
        {
            return mData.GetAll();
        }

        public ModuloUsuario GetOne(int IdModulo,int IdUsuario)
        {
            return mData.GetOne(IdModulo,IdUsuario);
        }

        public void Delete(int IdModulo, int IdUsuario)
        {
            mData.Delete(IdModulo, IdUsuario);
        }

        public void Save(ModuloUsuario moduloUsuario)
        {
            mData.Save(moduloUsuario);
        }
    }
}


