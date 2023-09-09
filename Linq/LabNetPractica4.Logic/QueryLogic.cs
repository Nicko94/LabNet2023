using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabNetPractica4.Entities;
using LabNetPractica4.UI;
//using Sitecore.FakeDb;

namespace LabNetPractica4.Logic
{
    public class QueryLogic : BaseLogic
    {
        private DelayOutput D = new DelayOutput();

        public void ClientObject() // A)
        {
            // SQL Generado
            //Db.Database.Log = Console.WriteLine();
            var cliente = context.Customers.Take(1).ToList();

            if (cliente.Count() == 0)
            {
                throw new CustomException("No se encontró el primer Cliente en la Base de Datos (QueryLogic.cs/line: 39)");
            }
            else
            {
                D.ListDelay("\n| ID | Empresa | Contacto | País | Dirección | Teléfono |\n");
                foreach (var c in cliente)
                {
                    D.ListDelay($"{c.CustomerID} - {c.CompanyName} - {c.ContactName} - {c.Country} - {c.Address} - {c.Phone}");
                }
            }
        }

        public void OutOfStockProducts() // B)
        {
            var products = from producto in context.Products where producto.UnitsInStock == 0 select producto;
            D.ListDelay("\nProductos sin stock:\n");
            D.ListDelay("| Nombre Producto |\n");
            foreach (var p in products)
            {
                D.ListDelay($"{p.ProductName}");
            }
        }
        
        public void OnStockValueOverThree() // C)
        {
            var products = from producto in context.Products where producto.UnitsInStock != 0 && producto.UnitPrice > 3 select producto;
            D.ListDelay("\nProductos en Stock de valor mayor a 3 (Tres):\n");
            D.ListDelay("| Nombre Producto | Stock | Precio |\n");

            foreach (var p in products)
            {
                D.ListDelay($"{p.ProductName} - {p.UnitsInStock} - ${p.UnitPrice}");
            }
        }

        public void RegionWACustomers() // D)
        {
            var customers = from cliente in context.Customers where cliente.Region == "WA" select cliente;
            D.ListDelay("\nClientes de la región \"WA\":\n");
            D.ListDelay("| Cliente | Contacto |\n");
            foreach (var c in customers)
            {
                D.ListDelay($"{c.CompanyName} - {c.ContactName}");
            }
        }

        public void ProductNumber789() // E)
        {
            var product = context.Products.Where(p => p.ProductID == 789).FirstOrDefault();
            if (product == null)
            {
            
                throw new CustomException($"\nEl Producto no se encontró en la Base de Datos");
            }
            else
            {
                D.ListDelay("\nProducto N° 789\n");
                D.ListDelay("| ID | Nombre Producto | Precio |\n");
                D.ListDelay($"{product.ProductID} - {product.ProductName} - ${product.UnitPrice}");
            }
        }

        public void CustomersUpperThenLower() // F)
        {
            int i = 0;
            var customers = context.Customers.ToList();

            while (i < 2)
            {
                switch (i)
                {
                    case 0:
                        D.ListDelay("\nClientes en Mayúsculas:\n");
                        D.ListDelay("| ID | Cliente |");
                        break;
                    case 1:
                        D.ListDelay("\nClientes en Minúsculas:\n");
                        D.ListDelay("| ID | Cliente |");
                        break;
                    default:
                        break;
                }
                foreach (var c in customers)
                {
                    if(i == 0)
                    {
                        D.ListDelay($"{c.CustomerID.ToUpper()} - {c.CompanyName.ToUpper()}");
                    }
                    else if (i == 1)
                    {
                        D.ListDelay($"{c.CustomerID.ToLower()} - {c.CompanyName.ToLower()}");
                    }
                    else
                    {
                        break;
                    }
                }
                i++;
            }
        }

        public void CustomersJoinOrders() // G)
        {
            var customersJoinOrders = from customer in context.Customers
                                  join orders in context.Orders
                                  on new { customer.CustomerID } equals new { orders.CustomerID }
                                  where customer.Region == "WA" && orders.OrderDate > new DateTime(1997, 1, 1)
                                  select new
                                  {
                                      customer.Region,
                                      orders.OrderDate,
                                      customer.CompanyName
                                  };
            D.ListDelay("\nClientes de la región \"WA\" con órdenes de fecha posterior al 01/01/1997\n");
            D.ListDelay("\n| Cliente | Región | Fecha de Orden |\n");
            foreach (var cjo in customersJoinOrders)
            {
                D.ListDelay($"{cjo.CompanyName} - {cjo.Region} - {cjo.OrderDate}");
            }
        }

        public void FirstThreeWA() // H)
        {
            var customers = context.Customers.Where(c => c.Region == "WA").Take(3).ToList();
            D.ListDelay("\nPrimeros 3 (Tres) Clientes con región \"WA\"");
            D.ListDelay("\n| ID | Cliente | Contacto | Región |\n");
            foreach (var c in customers)
            {
                D.ListDelay($"{c.CustomerID} - {c.CompanyName} - {c.ContactName} - {c.Region}");
            }
        }

        public void ProductsByName() // I)
        {
            var products = context.Products.OrderBy(p => p.ProductName).ToList();
            D.ListDelay("\n| Nombre Producto |\n");
            foreach (var p in products)
            {
                D.ListDelay($"{p.ProductName}");
            }
        }

        public void ProductsByUnitsInStock() // J)
        {
            var products = context.Products.OrderByDescending(p => p.UnitsInStock).ToList();
            D.ListDelay("\n| Nombre Producto | Unidades en Stock |\n");
            foreach (var p in products)
            {
                D.ListDelay($"{p.ProductName} - {p.UnitsInStock}");
            }
        }

        public void ProductsCategories() // K)
        {
            var categories = from product in context.Products
                                      join category in context.Categories
                                      on product.CategoryID equals category.CategoryID
                                      select new
                                      {
                                          product.ProductName,
                                          category.CategoryName
                                      };

            var everyProductsCategories = categories.Distinct().ToList();
            D.ListDelay("\n| Nombre Producto | Categoría |\n");
            foreach (var epc in everyProductsCategories)
            {
                D.ListDelay($"{epc.ProductName} - {epc.CategoryName}");

            }
        }

        public void FirstProduct() // L)
        {
            var product = context.Products.First();
            D.ListDelay("Primer Producto de la lista:\n");
            D.ListDelay("| ID | Nombre Producto | Stock | Precio |\n");
            D.ListDelay($"{product.ProductID} - {product.ProductName} - {product.UnitsInStock} - ${product.UnitPrice}");

        }

        public void CustomersOrders() // M)
        {
            var customersOrders = from orden in context.Orders
                                        join cliente in context.Customers
                                                                    on orden.CustomerID equals cliente.CustomerID
                                        select new { cliente.CompanyName, orden.CustomerID } into consulta
                                        group consulta by new { consulta.CompanyName } into g
                                        select new
                                        {
                                            CompanyNames = g.Key.CompanyName,
                                            CustomerID = g.Select(o => o.CustomerID).Count()
                                        };
            D.ListDelay("Clientes con su cantidad de Órdenes asociadas:\n");
            D.ListDelay("| Cliente | Cantidad de Órdenes |\n");
            foreach (var co in customersOrders)
            {
                D.ListDelay($"{co.CompanyNames} - {co.CustomerID}");
            }
        }
    }
}
