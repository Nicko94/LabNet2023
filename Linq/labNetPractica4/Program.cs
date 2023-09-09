using LabNetPractica4.Logic;
using LabNetPractica4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabNetPractica4.UI;

namespace labNetPractica4.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuLogic Menu = new MenuLogic();

            while (!Menu.GetExitValue())
            {
                Menu.ExecuteMenu();
            }
            /*
            1. Query para devolver objeto customer ------------
            2. Query para devolver todos los productos sin stock ---------------
            3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad ----------
            4. Query para devolver todos los customers de la Región WA
            5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789
            6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en minuscula.
            7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.

            Los siguientes ejercicios no son obligatorios, pero es deseable que estén resueltos:

            8. Query para devolver los primeros 3 Customers de la  Región WA
            9. Query para devolver lista de productos ordenados por nombre
            10. Query para devolver lista de productos ordenados por "unit in stock" de mayor a menor.
            11. Query para devolver las distintas categorías asociadas a los productos
            12. Query para devolver el primer elemento de una lista de productos
            13. Query para devolver los customer con la cantidad de ordenes asociadas
            */
        }
    }
}
