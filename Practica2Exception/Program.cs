using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
// May be I should delete the next using since the former includes everything in "System.Threading"
using System.Threading.Tasks;

namespace Practica2Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CERO = 0;
            //string miMensaje = "Usted no tiene la potestad para crear un agujero negro. Por favor póngase en contacto con su deidad de confianza para efectuar la división";
            string miMensaje = "\nUSTED NO PUEDE HACER SEMEJANTE BARBARIDAD, USTED TIENE QUE ARREPENTIRSE DE LO QUE HIZO.";

            // Función menú
            void menu()
            {
                bool bucle = true;
                bool corriendo = true;
                int opcion;
                int cantidadOpciones = 3;
                while (bucle)
                {
                    if (corriendo) { 
                        Console.WriteLine("Seleccione la operación a realizar\n");
                        Console.WriteLine("1) Intentar dividir un número por cero");
                        Console.WriteLine("2) Dividir dos números a elección");
                        Console.WriteLine("3) Cerrar el programa\n");

                        opcion = Convert.ToInt32(Console.ReadLine());
                        if (opcion > cantidadOpciones || opcion <= 0)
                        {
                            Console.WriteLine("\nLa opción elegida está fuera de rango, por favor seleccione un ítem válido del menú\n");
                        }
                        else
                        {
                            bucle = false;
                            switch (opcion)
                            {
                                case 1:
                                    dividirPorCero();
                                    break;
                                case 2:
                                    operarDivision();
                                    break;
                                case 3:
                                    cerrarPrograma();
                                    corriendo = false;
                                    break;
                                default:
                                    Console.WriteLine("Si usted llegó a este error, por favor explíqueme cómo. Gracias. CÓDIGO DE ERROR: WTF");
                                    break;
                            }
                        }
                    }
                    //Console.ReadKey();
                }

            }

            bool comprobarResultado(bool e)
            {
                if(e){
                    Console.WriteLine("Operación exitosa\n");
                    menu();
                }else{
                    Console.WriteLine("Operación fallida\n");
                    menu();
                }
                return e;
            }

            // Función del ejercicio 1
            float dividirPorCero()
            {
                bool exito = false;
                float r;
                Console.WriteLine("\nIngrese un valor numérico para ser dividido por 0 (cero)");
                int valor = Convert.ToInt32(Console.ReadLine());
                try
                {
                    r = valor / CERO;
                    exito = true;
                    return r;
                }
                catch (DivideByZeroException ex)
                {
                    exito = false;
                    Console.WriteLine(ex.Message);
                    return 0;
                }
                catch (Exception ex)
                {
                    exito = false;
                    Console.WriteLine(ex.Message);
                    return 0;
                }
                finally
                {
                    comprobarResultado(exito);
                }
            }



            // Función del ejercicio 2
            float operarDivision()
            {
                bool exito = false;
                float r;
                int a, b;

                try
                {
                    Console.WriteLine("\nIngrese el dividendo:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nIngrese el divisor:");
                    b = Convert.ToInt32(Console.ReadLine());
                    r = a / b;
                    Console.WriteLine("\nEl resultado es: {0}\n", r);
                    
                    exito = true;
                    return 0;
                }
                catch (FormatException)
                {
                    Console.WriteLine("¡Seguro ingresó una letra o no ingresó nada!");
                    return 0;
                }
                catch (DivideByZeroException ex)
                {
                    exito = false;
                    Console.WriteLine("{0}\n{1}", miMensaje, ex.Message);
                    return 0;
                }/*
                catch (FormatException)
                {
                    Console.WriteLine("¡Seguro ingresó una letra o no ingresó nada!");
                    return 0;
                }*/
                catch (Exception ex)
                {
                    exito = false;
                    Console.WriteLine("{0}\n{1}", miMensaje, ex.Message);
                    return 0;
                }
                finally
                {
                    comprobarResultado(exito);
                }
            }

            void cerrarPrograma()
            {
                bool bucle = true;
                while (bucle)
                {
                    Console.Write("\n\n3");
                    Thread.Sleep(100);
                    Console.Write(".");
                    Thread.Sleep(100);
                    Console.Write(".");
                    Thread.Sleep(100);
                    Console.WriteLine(".");
                    Thread.Sleep(100);
                    Console.Write("2");
                    Thread.Sleep(100);
                    Console.Write(".");
                    Thread.Sleep(100);
                    Console.Write(".");
                    Thread.Sleep(100);
                    Console.WriteLine(".");
                    Thread.Sleep(100);
                    Console.Write("1");
                    Thread.Sleep(100);
                    Console.Write(".");
                    Thread.Sleep(100);
                    Console.Write(".");
                    Thread.Sleep(100);
                    Console.WriteLine(".");
                    Thread.Sleep(100);
                    Console.WriteLine("Bye!");
                    Thread.Sleep(700);
                    bucle = false;
                }
                
            }

            menu();

            //Console.WriteLine("\nPresione una tecla para finalizar el programa...");
            //Console.ReadKey();
        }
    }
}
