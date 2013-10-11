using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Materia : BusinessEntity
    {
        private String _descripcion;
        private int _hSemanales;
        private int _hTotales;
        private int _idPlan;
        private int _idMateria;


        public int IdMateria
        {
            get { return _idMateria; }
            set { _idMateria = value;}
        }


        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int HSemanales
        {
            get { return _hSemanales; }
            set { _hSemanales = value; }
        }

        public int HTotales
        {
            get { return _hTotales; }
            set { _hTotales = value; }
        }

        public int IdPlan
        {
            get { return _idPlan; }
            set { _idPlan = value; }
        }
    }
}
