using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            Usuario usuario = new Usuario();
            usuario.Menu();
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: usuario.ListadoGeneral();
                    break;
                case 2: usuario.Consultar();
                    break;
                case 3: usuario.Agregar();
                    break;
                case 4: usuario.Modificar();
                    break;
                case 5: usuario.Eliminar();
                    break;
            }
            Console.ReadKey();
        }
    }
}
