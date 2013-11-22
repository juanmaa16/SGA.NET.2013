using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Plan : BusinessEntity
    {
        private String _descripcion;
        private int _idEspecialidad;
        private int _idPlan;
        private String _descEspecialidad;

        public String DescEspecialidad
        {
            get { return _descEspecialidad; }
            set { _descEspecialidad = value; }
        }

        public int IdPlan
        {
            get { return _idPlan; }
            set { _idPlan = value; }
        }

        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int IdEspecialidad
        {
            get { return _idEspecialidad; }
            set { _idEspecialidad = value; }
        }


    }
}
