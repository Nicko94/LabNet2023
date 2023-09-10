using LabNetPractica3.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNetPractica3.Logic
{
    public class SuppliersLogic : BaseLogic
    {
        public List<Supplier> GetAll()
        {
            Console.WriteLine("Cargando lista de PROVEEDORES...");
            Console.WriteLine("\nN°) Id - Nombre - Contacto - Web - Teléfono\n");
            return context.Suppliers.ToList();
        }

        public Supplier Find(int id)
        {
            return context.Suppliers.Find(id);
        }
        
        public void Update(Supplier supplier)
        {
            try
            {
                context.Suppliers.AddOrUpdate(supplier);
                context.SaveChanges();
                Console.WriteLine("[Operación exitosa]");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al actualizar PROVEEDOR: " + e.Message);

            }
        }

        public void Add(Supplier supplier)
        {
            try
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
                Console.WriteLine("[Operación exitosa]");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al ingresar PROVEEDOR: " + e.Message);
            }
        }

        public void Delete(int id)
        {
            // var DeleteShipper = context.Shippers.First(r => r.ShipperID == id);

            // var DeleteShipper = context.Shippers.FirstOrDefault(r => r.ShipperID == id);

            // var DeleteShipper = context.Shippers.Single(r => r.ShipperID == id);

            // var DeleteShipper = context.Shippers.SingleOrDefault(r => r.ShipperID == id);

            var DeleteSupplier = context.Suppliers.Find(id);

            if (DeleteSupplier != null)
            {
                try
                {
                    context.Suppliers.Remove(DeleteSupplier);
                    context.SaveChanges();
                    Console.WriteLine("[Operación exitosa]");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al eliminar PROVEEDOR" + e.Message);
                    throw new Exception();
                }
            }
            else
            {
                Console.WriteLine($"\nNo se encontró el PROVEEDOR de ID: { id }");
            }

        }
    }
}
