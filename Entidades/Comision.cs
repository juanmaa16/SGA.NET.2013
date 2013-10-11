using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Comision : BusinessEntity
    {
        private int _anioEspecialidad;
        private String _descripcion;
        private int _idPlan;
        private int _idEntidad;
        private int _idComision;
       
        public int IdComision
        {
            get { return _idComision; }
            set { _idComision = value; }
        }

        public int IdEntidad
        {
            get { return _idEntidad; }
            set { _idEntidad = value; }
        }

        public int AnioEspecialidad
        {
            get { return _anioEspecialidad; }
            set { _anioEspecialidad = value; }
        }

        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int IdPlan
        {
            get { return _idPlan; }
            set { _idPlan = value; }
        }

    }
}
