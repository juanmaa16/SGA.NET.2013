using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class ModuloUsuario : BusinessEntity
    {
        private int _idModulo;
        private int _idUsuario;
        private bool _permiteAlta;
        private bool _permiteBaja;
        private bool _permiteConsulta;
        private bool _permiteModificacion;

        public int IdModulo
        {
            get { return _idModulo; }
            set { _idModulo = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public bool PermiteAlta
        {
            get { return _permiteAlta; }
            set { _permiteAlta = value; }
        }

        public bool PermiteBaja
        {
            get { return _permiteBaja; }
            set { _permiteBaja = value; }
        }

        public bool PermiteConsulta
        {
            get { return _permiteConsulta; }
            set { _permiteConsulta = value; }
        }

        public bool PermiteModificacion
        {
            get { return _permiteModificacion; }
            set { _permiteModificacion = value; }
        }




    }
}
