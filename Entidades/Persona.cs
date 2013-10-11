using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Persona : BusinessEntity
    {
        private int _idPersona;
        private String _apellido;
        private String _direccion;
        private String _email;
        private String _nombre;
        private String _telefono;
        private DateTime _fechaNacimiento;
        private int _idPlan;
        private int _legajo;
        private TiposPersona _tipoPersona;

        public int IdPersona
        {
            get { return _idPersona; }
            set { _idPersona = value; }
        }

        public String Apellido
        {
            get{ return _apellido; }
            set { _apellido = value; }
        }

        public String Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public String Email
        {
            get{ return _email;}
            set{ _email = value;}
        }

        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public String Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public int IdPlan
        {
            get { return _idPlan; }
            set { _idPlan = value; }
        }
        public int Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }

        public TiposPersona TipoPersona
        {
            get { return _tipoPersona; }
            set { _tipoPersona = value; }
        }

        public enum TiposPersona
        {
            Alumno,
            Docente
        }

    }
}
