using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class CursoLogic : BusinessLogic
    {
         CursoAdapter cData;

        public CursoLogic()
        {
           this.cData = new CursoAdapter();
        }

        public CursoAdapter CursoData
        {get;set;}

        public List<Curso> GetAll()
        {
            return  cData.GetAll();
        }

        public Curso GetOne(int ID)
        {
            return cData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            cData.Delete(ID);
        }

        public void Save(Curso curso)
        {
            cData.Save(curso);
        }



    }
}
