using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic UsuarioNegocio;

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            int op = 0;
            while (op != 6)
            {
                Console.Clear();
                Console.WriteLine("MENU DE USUARIO");
                Console.WriteLine("1. Listado General");
                Console.WriteLine("2. Consultar");
                Console.WriteLine("3. Agregar");
                Console.WriteLine("4. Modificar");
                Console.WriteLine("5. Eliminar");
                Console.WriteLine("6. Salir");
                Console.Write("Ingrese una opción: ");
                try {
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            ListadoGeneral();
                            break;
                        case 2:
                            Consultar();
                            break;
                        case 3:
                            Agregar();
                            break;
                        case 4:
                            Modificar();
                            break;
                        case 5:
                            Eliminar();
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Lo siento, opción incorrecta.");
                            break;
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }            
            }
        }
        private void ListadoGeneral()
        {
            Console.Clear();

            foreach (Usuario u in UsuarioNegocio.GetAll() )
            {
                MostrarDatos(u);
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        private void Consultar()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del usuario a consultar: ");

            try
            {
                int Id = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(Id));
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
            
        }
        private void Agregar()
        {
            Console.Clear();
            Usuario u = new Usuario();
            Console.Write("Ingrese nombre: ");
            u.Nombre = Console.ReadLine();
            Console.Write("Ingrese apellido: ");
            u.Apellido = Console.ReadLine();
            Console.Write("Ingrese nombre del usuario: ");
            u.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese clave: ");
            u.Clave = Console.ReadLine();
            Console.Write("Ingrese email: ");
            u.Email = Console.ReadLine();
            Console.Write("Ingrese habilitación de usuario (1-Si/otro-No): ");
            u.Habilitado = (Console.ReadLine() == "1");
            u.State = TiposDatos.States.New;
            UsuarioNegocio.Save(u);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", u.Id);
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        private void Modificar()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del usuario a modificar: ");

            try
            {
                int Id = int.Parse(Console.ReadLine());
                Usuario u = UsuarioNegocio.GetOne(Id);
                Console.Write("Ingrese nombre: ");
                u.Nombre = Console.ReadLine();
                Console.Write("Ingrese apellido: ");
                u.Apellido = Console.ReadLine();
                Console.Write("Ingrese nombre del usuario: ");
                u.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese clave: ");
                u.Clave = Console.ReadLine();
                Console.Write("Ingrese email: ");
                u.Email = Console.ReadLine();
                Console.Write("Ingrese habilitación de usuario (1-Si/otro-No): ");
                u.Habilitado = (Console.ReadLine() == "1");
                u.State = TiposDatos.States.Modified;
                UsuarioNegocio.Save(u);    
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        private void Eliminar()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del usuario a eliminar: ");

            try
            {
                int Id = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(Id);
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        private void MostrarDatos(Usuario u)
        {
            Console.WriteLine("Usuario: {0}", u.Id);
            Console.WriteLine("\t\tNombre: {0}", u.Nombre);
            Console.WriteLine("\t\tApellido: {0}", u.Apellido);
            Console.WriteLine("\t\tNombre de usuario: {0}", u.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", u.Clave);
            Console.WriteLine("\t\tEmail: {0}", u.Email);
            Console.WriteLine("\t\tHabilitado: {0}", u.Habilitado);
            Console.WriteLine();
        }
    }
}
