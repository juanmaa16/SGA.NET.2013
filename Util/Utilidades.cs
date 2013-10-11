using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Util
{
    public class Utilidades
    {

        public static bool validaApellido(String apellido)
        {
            bool valida=true;
            if (apellido == "")
            {
                valida = false;
            }
            return valida;

        }

        public static bool validaNombre(String nombre)
        {
            bool valida = true;
            if (nombre == "")
            {
                valida = false;
            }
            return valida;
        }

        public static bool validaClavesIguales(String clave1, String clave2)
        {
            bool valida = true;
            if (clave1 != clave2)
            {
                valida = false;
            }
            return valida;
        }

        public static bool validaClaveCaracteres(String clave)
        {
            bool valida = true;
            if (clave.Length < 8)
            { valida = false; }
            return valida;
        }

        public static bool validaClave(String clave)
        {
            bool valida=true;
            if(clave=="")
            {valida=false;}
            return valida;
        }

        public static bool validaDireccion(String direccion)
        {
            bool valida = true;
            if (direccion == null)
            {
                valida = false;
            }
            return valida;
        }

        public static bool nombreUsuario(String nombreUsuario)
        {
            bool valida = true;
            if (nombreUsuario == null)
            {
                valida = false;
            }
            return valida;
        }

        public static bool validarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
