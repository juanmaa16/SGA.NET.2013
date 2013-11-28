using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private String _condicion;
        private int _idAlumno;
        private int _idCurso;
        private int _nota;
        private string _nombreAlumno;
        private string _apellidoAlumno;

        public string NombreAlumno
        {
            get { return _nombreAlumno; }
            set { _nombreAlumno = value; }
        }
        public string ApellidoAlumno
        {
            get { return _apellidoAlumno; }
            set { _apellidoAlumno = value; }
        }

        public String Condicion
        {
            get { return _condicion; }
            set { _condicion = value; }
        }
        public int IdAlumno
        {
            get { return _idAlumno; }
            set { _idAlumno = value; }
        }
        public int IdCurso
        {
            get { return _idCurso; }
            set { _idCurso = value; }
        }
        public int Nota
        {
            get { return _nota; }
            set { _nota = value; }
        }
    }

}
