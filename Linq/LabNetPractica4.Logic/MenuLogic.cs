using LabNetPractica4.Logic;
using System;
using System.Threading;
namespace LabNetPractica4.UI
{
    public class MenuLogic
    {
        private bool Exit { get; set; }

        public void ExitProgram()
        {
            Exit = true;
        }
        public bool GetExitValue()
        {
            return Exit;
        }

        private void PauseAndContinue()
        {
            DelayOutput delay = new DelayOutput();
            delay.TextDelay("\nPresione una tecla para continuar...\n");
            Console.ReadKey();
        }

        public MenuLogic()
        {
            this.Exit = false;
        }

        private void ShowMainMenu()
        {
            DelayOutput delay = new DelayOutput();

            Console.Clear();
            delay.ListDelay("A) Objeto Cliente");
            delay.ListDelay("B) Productos sin stock");
            delay.ListDelay("C) Productos en stock que cuestan más de 3 por unidad");
            delay.ListDelay("D) Clientes de la región WA");
            delay.ListDelay("E) Primer elemento o Nulo del Producto de ID: 789");
            delay.ListDelay("F) Nombres de Clientes en Mayúsculas y Minúsculas");
            delay.ListDelay("G) JOIN de Clientes de la región WA y Órdenes con fecha mayor a 1/1/1997");
            delay.ListDelay("H) Primeros 3 Clientes de la región WA");
            delay.ListDelay("I) Productos por Nombre");
            delay.ListDelay("J) Productos por Unidad en stock de mayor a menor");
            delay.ListDelay("K) Categorías asociadas a los Productos");
            delay.ListDelay("L) Primer elemento de lista de Productos");
            delay.ListDelay("M) Clientes con cantidad de Órdenes");
            delay.ListDelay("X) Cerrar el programa\n");
        }

        public void ExecuteMenu()
        {
            ShowMainMenu();
            string Option = Console.ReadLine();
            QueryLogic Query = new QueryLogic();
            DelayOutput delay = new DelayOutput();
            switch (Option.ToLowerInvariant())
            {
                case "a":
                    Query.ClientObject();
                    PauseAndContinue();
                    break;
                case "b":
                    Query.OutOfStockProducts();
                    PauseAndContinue();
                    break;
                case "c":
                    Query.OnStockValueOverThree();
                    PauseAndContinue();
                    break;
                case "d":
                    Query.RegionWACustomers();
                    PauseAndContinue();
                    break;
                case "e":
                    try
                    {
                        Query.ProductNumber789();
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (CustomException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        PauseAndContinue();
                    }
                    break;
                case "f":
                    Query.CustomersUpperThenLower();
                    PauseAndContinue();
                    break;
                case "g":
                    Query.CustomersJoinOrders();
                    PauseAndContinue();
                    break;
                case "h":
                    Query.FirstThreeWA();
                    PauseAndContinue();
                    break;
                case "i":
                    Query.ProductsByName();
                    PauseAndContinue();
                    break;
                case "j":
                    Query.ProductsByUnitsInStock();
                    PauseAndContinue();
                    break;
                case "k":
                    Query.ProductsCategories();
                    PauseAndContinue();
                    break;
                case "l":
                    Query.FirstProduct();
                    PauseAndContinue();
                    break;
                case "m":
                    Query.CustomersOrders();
                    PauseAndContinue();
                    break;
                case "n":
                    PauseAndContinue();
                    break;
                case "x":
                    GoodBye();
                    break;
                default:
                    Console.WriteLine("La opción seleccionada no es válida, por favor inténtelo nuevamente.");
                    Thread.Sleep(1000);
                    break;
            }
        }

        private void GoodBye()
        {
            ExitProgram();
            Console.Write("\n\n3");
            Thread.Sleep(100);
            Console.Write(".");
            Thread.Sleep(100);
            Console.Write(".");
            Thread.Sleep(100);
            Console.Write(".");
            Thread.Sleep(100);
            Console.Write("2");
            Thread.Sleep(100);
            Console.Write(".");
            Thread.Sleep(100);
            Console.Write(".");
            Thread.Sleep(100);
            Console.Write(".");
            Thread.Sleep(100);
            Console.Write("1");
            Thread.Sleep(100);
            Console.Write(".");
            Thread.Sleep(100);
            Console.Write(".");
            Thread.Sleep(100);
            Console.Write(".");
            Thread.Sleep(100);
            Console.WriteLine("Bye!");
            Thread.Sleep(700);
        }
    }
}
