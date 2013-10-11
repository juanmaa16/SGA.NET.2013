using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Curso : BusinessEntity
    {
        private int _idCurso;
        private int _anioCalendario;
        private int _cupo;
        private String _descripcion;
        private int _idComision;
        private int _idMateria;

        public int IdCurso
        {
            get { return _idCurso; }
            set { _idCurso = value; }
        }

        public int AnioCalendario
        {
            get { return _anioCalendario; }
            set { _anioCalendario = value; }
        }

        public int Cupo
        {
            get { return _cupo; }
            set { _cupo = value; }
        }

        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int IdMateria
        {
            get { return _idMateria; }
            set { _idMateria = value; }
        }

        public int IdComision
        {
            get { return _idComision; }
            set { _idComision = value; }
        }


    }
}
