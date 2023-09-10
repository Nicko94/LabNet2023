using LabNetPractica3.Data;
using LabNetPractica3.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.Logic
{
    public class ShippersLogic : BaseLogic
    {
        public List<Shipper> GetAll()
        {
            Console.WriteLine("Cargando lista de DISTRIBUIDORES...");
            Console.WriteLine("\nN°) Id - Nombre - Teléfono\n");
            return context.Shippers.ToList();
        }

        public Shipper Find(int id)
        {
            return context.Shippers.Find(id);
        }

        public void Add(Shipper shipper)
        {
            try
            {
                context.Shippers.Add(shipper);
                context.SaveChanges();
                Console.WriteLine("[Operación exitosa]");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar DISTRIBUIDOR: " + ex.Message);
            }
        }

        public void Update(Shipper shipper)
        {
            try
            {
                context.Shippers.AddOrUpdate(shipper);
                context.SaveChanges();
                Console.WriteLine("[Operación exitosa]");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar DISTRIBUIDOR: " + ex.Message);
            }
        }

        public void Delete(int ShipperID)
        {
            var DeleteShipper = context.Shippers.Find(ShipperID);

            if (DeleteShipper != null) 
            {
                try
                {
                    context.Shippers.Remove(DeleteShipper);
                    context.SaveChanges();
                    Console.WriteLine("[Operación exitosa]");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError al eliminar DISTRIBUIDOR" + ex.Message);
                    throw;
                }
            }
            else
            {
                Console.WriteLine($"\nNo se encontró el DISTRIBUIDOR de ID: { ShipperID }");
            }
        }
    }
}
