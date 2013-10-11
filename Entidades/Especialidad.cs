using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Especialidad : BusinessEntity
    {
        private String _descripcion;
        private int _idEspecialidad;
       
        public String Descripcion
        {
            get { return _descripcion;}
            set { _descripcion = value;}
        }

        public int IdEspecialidad
        {
            get { return _idEspecialidad; }
            set { _idEspecialidad = value; }
        }
    
    
    }
}
