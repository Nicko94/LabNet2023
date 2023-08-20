using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practica1POO
{
    internal class Omnibus : TransportePublico
    {
        const int CAPACIDAD_OMNI = 100;

        // Construyo un bondi con su identificación/capacidad correspondiente y 0 pasajeros
        public Omnibus(int idBondi) : base(idBondi, 0, CAPACIDAD_OMNI){}

        // Los ómnibus tienen caja automática
        public override void Avanzar()
        {
            Console.WriteLine("El ómnibus avanza con caja de cambios automática.");
        }

        // Los ómnibus se detienen con pastillas de freno
        public override void Detenerse()
        {
            Console.WriteLine("El ómnibus se detiene con pastillas de freno");
        }

    }
}
