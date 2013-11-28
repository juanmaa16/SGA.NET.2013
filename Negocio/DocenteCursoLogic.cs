using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class DocenteCursoLogic : BusinessLogic
    {
        DocenteCursoAdapter dcData;

        public DocenteCursoLogic()
        {
            this.dcData = new DocenteCursoAdapter();
        }

        public DocenteCursoAdapter DocenteCursoData
        { get; set; }

        public List<DocenteCurso> GetAll()
        {
            return dcData.GetAll();
        }

        public DocenteCurso GetOne(int ID_D, int ID_C)
        {
            return dcData.GetOne(ID_D, ID_C);
        }

        public void Delete(int ID_D, int ID_C)
        {
            dcData.Delete(ID_D, ID_C);
        }

        public void Save(DocenteCurso docentecurso)
        {
            dcData.Save(docentecurso);
        }

        public List<DocenteCurso> GetAllByDocente(int idDocente)
        {
            return dcData.GetAllByDocente(idDocente);
        }
    }
}