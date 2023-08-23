using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Exception
{
    /*
    public class DivisionImposibleException : Exception
    {
        public DivisionImposibleException()
        {
            Console.WriteLine("Salio la primera");
        }

        public DivisionImposibleException(string mensaje) : base(mensaje)
        {
            Console.WriteLine("Salio la segunda");
        }

        public DivisionImposibleException(string mensaje, Exception inner) : base(mensaje, inner)
        {
            Console.WriteLine("Salio la tercera");
        }
    }

    */

    public class DivisionImposibleException : Exception
    {
        //public DivisionImposibleException(string mensaje) : base("Usted no tiene la potestad para crear un agujero negro. Por favor póngase en contacto con su deidad de confianza para efectuar la división" + mensaje)
        public DivisionImposibleException(string mensaje) : base("Mi excepcion salió bien")
        {
            //throw new DivideByZeroException(mensaje);
            throw new Exception("Sólo Chuck Norris divide por cero!");
        }
    }
}
