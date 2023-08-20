using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Practica1POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creo lista de transportes
            List<TransportePublico> ListaVehiculos = new List<TransportePublico>()
            {
                new Omnibus(1),
                new Omnibus(2),
                new Omnibus(3),
                new Omnibus(4),
                new Omnibus(5),
                new Taxi(1),
                new Taxi(2),
                new Taxi(3),
                new Taxi(4),
                new Taxi(5)
            };

            bool validacion(string entradaUsuario, int capacidadVehiculo)
            {
                try
                {
                    int ingreso = Convert.ToInt32(entradaUsuario);
                    return ingreso <= capacidadVehiculo && ingreso >= 0;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Ingreso no válido, entrada numérica requerida.");
                    Console.WriteLine(e.Message);
                }
                return false;
            }
     
            Console.WriteLine("A continuación se pondrá a su disposición la lista de vehículos disponibles, donde podrá cargar los pasajeros deseados:\n");

            // Ingresa la cantidad de pasajeros para cada vehículo            
            string cuantosSuben;

            foreach (var j in ListaVehiculos)
            {
                Console.WriteLine("Ingrese la cantidad de pasajeros del {0} número {1}", j.GetType().Name, j.MostrarPatente());
                cuantosSuben = Console.ReadLine();

                while (!validacion(cuantosSuben, j.MostrarCapacidad()))
                {
                    Console.WriteLine("Fuera de rango, intente de nuevo.");
                    cuantosSuben = Console.ReadLine();
                }

                int pasajerosValidos = Convert.ToInt32(cuantosSuben);
                j.AbordarPasajeros(pasajerosValidos);                
            }

            Console.WriteLine("\n");

            foreach (var j in ListaVehiculos)
            {
                Console.WriteLine("{0} {1}: {2} pasajeros", j.GetType().Name, j.MostrarPatente(), j.MostrarPasajeros());
            }
            Console.WriteLine("\n Presione una tecla para finalizar el programa...");
            Console.ReadKey();
        }
    }
}
