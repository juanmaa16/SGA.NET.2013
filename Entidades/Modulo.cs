using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Modulo : BusinessEntity
    {
        private String _descripcion;
        private String _ejecuta;
        private int _idModulo;

        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public String Ejecuta
        {
            get { return _ejecuta; }
            set { _ejecuta = value; }
        }
        public int IDModulo
        {
            get { return _idModulo; }
            set { _idModulo = value; }
        }
    }
}
