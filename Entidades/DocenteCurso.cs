using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class DocenteCurso : BusinessEntity
    {
        private TiposCargo _cargo;
        private int _idCurso;
        private int _idDocente;
        private string _descMateria;

        public TiposCargo Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        public int IdCurso
        {
            get { return _idCurso; }
            set { _idCurso = value; }
        }

        public int IdDocente
        {
            get { return _idDocente; }
            set { _idDocente = value; }
        }

        public enum TiposCargo
        {
            Titular,
            Provisional
        }

        public string DescMateria
        {
            get { return _descMateria; }
            set { _descMateria = value; }
        }
    }
}
