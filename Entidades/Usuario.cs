using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Usuario : BusinessEntity
    {
        private String _nombre;
        private String _apellido;
        private int _ID; 
        private String _nombreUsuario;
        private String _password;
        private Boolean _habilitado;
        private String _email;
        private String _telefono;
        private DateTime _fechaNacimiento;
        private int _idPlan;
        private int _legajo;
        private TiposPersona _tipoPersona;
        private String _direccion;
        private String _tipoDocumento;
        private int _nroDocumento;
        private String _celular;

        public String Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        public int NroDocumento
        {
            get { return _nroDocumento; }
            set { _nroDocumento = value; }
        }

        public String TipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }

        public String Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public String Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public String NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Boolean Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
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
            Docente,
            Administrador
        }


 


    }
}
