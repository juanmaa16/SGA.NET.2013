using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio;
using Entidades;

namespace UI.Consola
{
    public class Usuario
    {
        private UsuarioLogic _uNegocio;
        public Usuario()
        {
           this._uNegocio = new UsuarioLogic() ;
        }

        public UsuarioLogic UsuarioNegocio
        { get; set; }

        public void Menu()
        {
            Console.WriteLine("1-Listado General \n2-Consulta \n3-Agregar \n4-Modificar \n5-Eliminar \n6-Salir");
             
        }

        public void MostrarDatos(Entidades.Usuario user)
        {
            Console.WriteLine("Usuario: {0}" + user.ID);
            Console.WriteLine("\t\tNombre: {0}" + user.Nombre);
            Console.WriteLine("\t\tApellido: {0}" + user.Apellido);
            Console.WriteLine("\t\tNombre de usuario: {0}" + user.NombreUsuario);
            Console.WriteLine("\t\tPassword: {0}" + user.Password);
            Console.WriteLine("\t\tEmail: {0}" + user.Email);
            Console.WriteLine("\t\tHabilitado: {0}" + user.Habilitado);
            Console.WriteLine();

        }

        public void ListadoGeneral()
        {
            Console.Clear();
            List<Entidades.Usuario> uLista = new List<Entidades.Usuario>();
            uLista=_uNegocio.GetAll();
            foreach (Entidades.Usuario user in uLista)
            {
                MostrarDatos(user);
            }
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(_uNegocio.GetOne(ID));
            }

            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("Solo se puede ingresar numeros");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
            }
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID del usuario a modificar");
                int ID = int.Parse(Console.ReadLine());
                Entidades.Usuario usuario = _uNegocio.GetOne(ID);
                Console.WriteLine("Ingrese nombre");
                usuario.Nombre= Console.ReadLine();
                Console.WriteLine("Ingrese apellido");
                usuario.Apellido= Console.ReadLine();
                Console.WriteLine("Ingrese Nombre de usuario");
                usuario.NombreUsuario= Console.ReadLine();
                Console.WriteLine("Ingrese password");
                usuario.Password= Console.ReadLine();
                Console.WriteLine("Ingrese Email");
                usuario.Email= Console.ReadLine();
                Console.WriteLine("Ingrese habilitado (1-Si/Otro-No)");
                usuario.Habilitado= (Console.ReadLine()=="1");
                usuario.State= BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);

            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("Solo se puede ingresar numeros");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
            }
        }

        public void Agregar()
        {
            Entidades.Usuario usuario = new Entidades.Usuario();
            Console.Clear();
            Console.WriteLine("Ingrese nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nombre de usuario");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese password");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingrese Email");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese habilitacion de usuario (1-Si/Otro=NO)");
            usuario.Habilitado = (Console.ReadLine()=="1");
            usuario.State = BusinessEntity.States.New;
            _uNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }

        public void Eliminar()
        {
            try 
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a eliminar");
                int ID = int.Parse(Console.ReadLine());
                _uNegocio.Delete(ID);
                Console.WriteLine("Usuario eliminado con éxito");
            }
             
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("Solo se puede ingresar numeros");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
            }
        }


    }
}
