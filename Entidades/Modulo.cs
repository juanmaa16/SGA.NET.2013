using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Modulo : BusinessEntity
    {
        private String _descripcion;

        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}
