using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class PersonaLogic : BusinessLogic
    {
        PersonaAdapter pData;

        public PersonaLogic()
        {
            this.pData = new PersonaAdapter();
        }

        public PersonaAdapter PersonaData
        {
            get;
            set;
        }

        public List<Persona> GetAll()
        {
            return pData.GetAll();
        }

        public Persona GetOne(int ID)
        {
            return pData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            pData.Delete(ID);
        }

        public void Save(Persona persona)
        {
            pData.Save(persona);
        }
    }
}
