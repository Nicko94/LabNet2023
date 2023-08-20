using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1POO
{
    public abstract class TransportePublico
    {
        // Parametros
        private int patente { get; set; }
        private int pasajeros { get; set; }
        private int capacidad { get; set; }
        private string tipo { get; set; }

        // Constructor
        public TransportePublico(int patente, int pasajeros, int capacidad)
        {
            this.patente = patente;
            this.pasajeros = pasajeros;
            this.capacidad = capacidad;
        }
        
        // Metodos
        public abstract void Avanzar();
        public abstract void Detenerse();
        public int MostrarPatente()
        {
            return this.patente;
        }
        public void AbordarPasajeros(int cantidad)
        {
            if(this.capacidad > this.pasajeros){ 
                pasajeros += cantidad;
            }else{
                Console.WriteLine("Capacidad exedida.");
            }

        }
        public int MostrarPasajeros()
        {
            return pasajeros;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine("{0} {1}: {2} pasajeros", this.GetType().Name, this.MostrarPatente(), this.MostrarPasajeros());
        }

        public int MostrarCapacidad()
        {
            return this.capacidad;
        }

    }
}
