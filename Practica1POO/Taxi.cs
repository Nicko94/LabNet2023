using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1POO
{
    public class Taxi : TransportePublico
    {
        const int CAPACIDAD_TAXI = 4;

        // Se construye un taxi con su identificador/capacidad correspondiente y 0 pasajeros
        public Taxi(int idTaxi) : base(idTaxi, 0, CAPACIDAD_TAXI){}

        // Los taxis tienen caja manual
        public override void Avanzar()
        {
            Console.WriteLine("El taxi avanza con la caja de cambios en primera");
        }

        // Los taxis se detienen con discos de freno
        public override void Detenerse()
        {
            Console.WriteLine("El taxi se detiene con discos de freno");
        }

    }
}
