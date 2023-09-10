using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabNetPractica3.Data;
using LabNetPractica3.Entities;

namespace LabNetPractica3.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public List<Customer> GetAll()
        {
            Console.WriteLine("Cargando lista de CLIENTES...");
            Console.WriteLine("\nN°) Id - Nombre - Título - Empresa - Teléfono\n");
            return context.Customers.ToList();
        }

        public Customer Find(string id)
        {
            return context.Customers.FirstOrDefault(r => r.CustomerID == id);
        }

        public void Add(Customer customer)
        {
            try
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                Console.WriteLine("[Operación exitosa]");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar CLIENTE: " + ex.Message);
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                context.Customers.AddOrUpdate(customer);
                context.SaveChanges();
                Console.WriteLine("[Operación exitosa]");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar CLIENTE: " + ex.Message);
            }
        }

        public void Delete(string id)
        {
            var DeleteCustomer = context.Customers.Find(id);
            if (DeleteCustomer!= null)
            {
                try
                {
                    context.Customers.Remove(DeleteCustomer);
                    context.SaveChanges();
                    Console.WriteLine("[Operación exitosa]");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar CLIENTE: " + ex.Message);
                    throw new Exception();
                }
            }
            else
            {
                Console.WriteLine($"\nNo se encontró el CLIENTE de ID: { id }");
            }
        }
    }
}
