using LabNetPractica3.Entities;
using LabNetPractica3.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabNetPractica3.UI
{
    public class MenuLogic
    {
        private int i {  get; set; }
        private bool Exit { get; set; }
        private bool Success { get; set; }
        private string CurrentMenu { get; set; }
        public string Confirmation { get; set; }
        public bool ValidConfirmation { get; set; }

        private int id;
        private string contactName;
        private string contactTitle;
        private string companyName;
        private string phone;
        private string web;
        private string IdNchar;

        private void ResetI()
        {
            this.i = 0;
        }
        private void IncrementI()
        {
            this.i++;
        }
        public void SetExitValue(bool exit)
        {
            this.Exit = exit;
        }
        public bool GetExitValue()
        {
            return this.Exit;
        }
        public void SetCurrentMenu(string option)
        {
            this.CurrentMenu = option;
        }
        private string GetCurrentMenu()
        {
            return this.CurrentMenu;
        }

        public MenuLogic()
        {
            this.i = 0;
            this.Exit = false;
            this.Success = false;
            this.IdNchar = "";
            this.CurrentMenu = "0";
            this.ValidConfirmation = false;
        }

        public void ExecuteMenu()
        {
            switch (GetCurrentMenu())
            {
                case "0":
                    this.ShowMainMenu();
                    break;
                case "1":
                    this.ShowSubMenuSelect();
                        break;
                case "2":
                    this.ShowSubMenuInsert();
                    break;
                case "3":
                    this.ShowSubMenuUpdate();
                    break;
                case "4":
                    this.ShowSubMenuDelete();
                    break;
                case "5":
                    SetExitValue(true);
                    GoodBye();
                    break;
                default:
                    Console.WriteLine("La opción seleccionada no es válida, por favor inténtelo nuevamente.");
                    Thread.Sleep(1000);
                    this.ShowMainMenu();
                    break;
            }
        }

        private void ShowMainMenu()
        {
            DelayOutput delay = new DelayOutput();

            Console.Clear();
            delay.ListDelay("1) Mostrar un listado");
            delay.ListDelay("2) Agregar un registro");
            delay.ListDelay("3) Actualizar un registro");
            delay.ListDelay("4) Eliminar un registro");
            delay.ListDelay("5) Cerrar el programa\n");

            this.SetCurrentMenu(Console.ReadLine());
        }

        public void ShowSubMenuSelect()
        {
            DelayOutput delay = new DelayOutput();
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                delay.TextDelay("Seleccione la lista que desea ver:\n|");
                delay.TextDelay("└ 1 - Clientes");
                delay.TextDelay("└ 2 - Distribuidores");
                delay.TextDelay("└ 3 - Proveedores");
                delay.TextDelay("└ 0 - Inicio");

                switch (Console.ReadLine())
                {
                    case "0":
                        loop = false;
                        SetCurrentMenu("0");
                        break;
                    case "1":
                        loop = false;

                        CustomersLogic customersLogic = new CustomersLogic();
                        foreach (Customer customer in customersLogic.GetAll())
                        {
                            IncrementI();
                            delay.ListDelay($"{i}) {customer.CustomerID} - {customer.ContactName} - {customer.ContactTitle} - {customer.CompanyName} - {customer.Phone}");
                        }
                        ResetI();

                        delay.TextDelay("\nPresione una tecla para volver al menú");
                        Console.ReadKey();
                        break;
                    case "2":
                        loop = false;

                        ShippersLogic shippersLogic= new ShippersLogic();
                        foreach (Shipper shipper in shippersLogic.GetAll())
                        {
                            IncrementI();
                            delay.ListDelay($"{i}) {shipper.ShipperID} -  {shipper.CompanyName} - {shipper.Phone}");
                        }
                        ResetI();

                        delay.TextDelay("\nPresione una tecla para volver al menú");
                        Console.ReadKey();
                        break;
                    case "3":
                        loop = false;

                        SuppliersLogic suppliersLogic = new SuppliersLogic();
                        foreach (Supplier supplier in suppliersLogic.GetAll())
                        {
                            IncrementI();
                            delay.ListDelay($"{i}) {supplier.SupplierID} - {supplier.CompanyName} - {supplier.ContactName} - {supplier.HomePage} - {supplier.Phone}");
                        }
                        ResetI();

                        delay.TextDelay("\nPresione una tecla para volver al menú");
                        Console.ReadKey();
                        break;
                    default:
                        delay.TextDelay("\nLa opción seleccionada no es válida, por favor inténtelo nuevamente.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        public void ShowSubMenuInsert()
        {
            DelayOutput delay = new DelayOutput();
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                delay.TextDelay("Seleccione la tabla a la que quiera agregar un registro:\n|");
                delay.TextDelay("└ 1 - Clientes");
                delay.TextDelay("└ 2 - Distribuidores");
                delay.TextDelay("└ 3 - Proveedores");
                delay.TextDelay("└ 0 - Inicio");

                switch (Console.ReadLine())
                {
                    case "0":
                        loop = false;
                        SetCurrentMenu("0");
                        break;
                    case "1":
                        loop = false;
                        ValidConfirmation = false;
                        delay.TextDelay("A continuación deberá ingresar los datos del nuevo CLIENTE que desea ingresar:");
                        delay.TextDelay("ID (nchar)");
                        IdNchar = Console.ReadLine();
                        delay.TextDelay("Nombre");
                        contactName = Console.ReadLine();
                        delay.TextDelay("Título");
                        contactTitle = Console.ReadLine();
                        delay.TextDelay("Empresa");
                        companyName = Console.ReadLine();
                        delay.TextDelay("Teléfono");
                        phone = Console.ReadLine();
                        CustomersLogic customersLogic = new CustomersLogic();
                        while (!ValidConfirmation)
                        {
                            delay.TextDelay("\n¿Está seguro/a que los datos son correctos? S/N:");
                            Confirmation = Console.ReadLine();
                            if (string.Equals(Confirmation, "S", StringComparison.OrdinalIgnoreCase))
                            {
                                customersLogic.Add(new Customer
                                {
                                    CustomerID = IdNchar,
                                    ContactName = contactName,
                                    ContactTitle = contactTitle,
                                    CompanyName = companyName,
                                    Phone = phone
                                });
                                ValidConfirmation = true;
                            }
                            else if (string.Equals(Confirmation, "N", StringComparison.OrdinalIgnoreCase))
                            {
                                delay.TextDelay("\n[Operación cancelada]");
                                ValidConfirmation = true;
                            }
                            else
                            {
                                Console.WriteLine("\nEntrada no válida. Ingrese S o N.");
                            }
                        }
                        delay.TextDelay("Presione una tecla para volver al menú");
                        Console.ReadKey();
                        break;
                    case "2":
                        loop = false;
                        ValidConfirmation = false;
                        delay.TextDelay("A continuación deberá completar los datos del nuevo DISTRIBUIDOR que desea ingresar:");
                        delay.TextDelay("Nombre de Empresa:");
                        companyName = Console.ReadLine();
                        delay.TextDelay("Teléfono");
                        phone = Console.ReadLine();
                        ShippersLogic shippersLogic = new ShippersLogic();
                        while (!ValidConfirmation)
                        {
                            delay.TextDelay("\n¿Está seguro/a que los datos son correctos? S/N:");
                            Confirmation = Console.ReadLine();
                            if (string.Equals(Confirmation, "S", StringComparison.OrdinalIgnoreCase))
                            {
                                shippersLogic.Add(new Shipper
                                {
                                    ShipperID = id,
                                    CompanyName = companyName,
                                    Phone = phone
                                });
                                ValidConfirmation = true;
                            }
                            else if (string.Equals(Confirmation, "N", StringComparison.OrdinalIgnoreCase))
                            {
                                delay.TextDelay("\n[Operación cancelada]");
                                ValidConfirmation = true;
                            }
                            else
                            {
                                Console.WriteLine("\nEntrada no válida. Ingrese S o N.");
                            }
                        }
                        delay.TextDelay("\nPresione una tecla para volver al menú");
                        Console.ReadKey();
                        break;
                    case "3":
                        loop = false;
                        ValidConfirmation = false;
                        delay.TextDelay("A continuación deberá ingresar los datos del nuevo PROVEEDOR:");
                        delay.TextDelay("Empresa");
                        companyName = Console.ReadLine();
                        delay.TextDelay("Contacto");
                        contactName = Console.ReadLine();
                        delay.TextDelay("Teléfono");
                        phone = Console.ReadLine();
                        SuppliersLogic suppliersLogic = new SuppliersLogic();

                        while (!ValidConfirmation)
                        {
                            delay.TextDelay("\n¿Está seguro/a que los datos son correctos? S/N:");
                            Confirmation = Console.ReadLine();
                            if (string.Equals(Confirmation, "S", StringComparison.OrdinalIgnoreCase))
                            {
                                suppliersLogic.Add(new Supplier
                                {
                                    SupplierID = id,
                                    CompanyName = companyName,
                                    ContactName = contactName,
                                    Phone = phone
                                });
                                ValidConfirmation = true;
                            }
                            else if (string.Equals(Confirmation, "N", StringComparison.OrdinalIgnoreCase))
                            {
                                delay.TextDelay("\n[Operación cancelada]");
                                ValidConfirmation = true;
                            }
                            else
                            {
                                Console.WriteLine("\nEntrada no válida. Ingrese S o N.");
                            }
                        }
                        delay.TextDelay("\nPresione una tecla para volver al menú");
                        break;
                    default:
                        delay.TextDelay("La opción seleccionada no es válida, por favor inténtelo nuevamente.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        public void ShowSubMenuUpdate()
        {
            DelayOutput delay = new DelayOutput();
            bool loop = true;
            string input;
            while (loop)
            {
                Console.Clear();
                delay.TextDelay("Seleccione la tabla de la que quiera actualizar un registro:\n|");
                delay.TextDelay("└ 1 - Clientes");
                delay.TextDelay("└ 2 - Distribuidores");
                delay.TextDelay("└ 3 - Proveedores");
                delay.TextDelay("└ 0 - Inicio\n");

                switch (Console.ReadLine())
                {
                    case "0":
                        loop = false;
                        SetCurrentMenu("0");
                        break;
                    case "1":
                        loop = false;
                        ValidConfirmation = false;
                        delay.TextDelay("Ingrese ID del CLIENTE que desea actualizar:\n");
                        input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input))
                        {
                            ValidConfirmation = true;
                            delay.TextDelay("Entrada NULL no válida");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        CustomersLogic customersLogic = new CustomersLogic();
                        Customer CustomerToUpdate = customersLogic.Find(input);
                        if(CustomerToUpdate == null)
                        {
                            delay.TextDelay($"No se encontró el registro de ID { id }");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        delay.TextDelay($"Datos actuales del CLIENTE seleccionado ==> Nombre: { CustomerToUpdate.ContactName} - Contacto: { CustomerToUpdate.ContactTitle} - Empresa: { CustomerToUpdate.CompanyName}\n");
                        delay.TextDelay("A continuación deberá ingresar los datos del CLIENTE que desea actualizar:");
                        delay.TextDelay("ID");
                        input = Console.ReadLine();
                        delay.TextDelay("Nombre");
                        contactName = Console.ReadLine();
                        delay.TextDelay("Título");
                        contactTitle = Console.ReadLine();
                        delay.TextDelay("Empresa");
                        companyName = Console.ReadLine();
                        delay.TextDelay("Teléfono");
                        phone = Console.ReadLine();
                        while (!ValidConfirmation)
                        {
                            delay.TextDelay("\n¿Está seguro/a que los datos son correctos? S/N:");
                            Confirmation = Console.ReadLine();

                            if (string.Equals(Confirmation, "S", StringComparison.OrdinalIgnoreCase))
                            {
                                customersLogic.Update(new Customer
                                {
                                    CustomerID = input,
                                    ContactName = contactName,
                                    ContactTitle = contactTitle,
                                    CompanyName = companyName,
                                    Phone = phone
                                });
                                ValidConfirmation = true;
                            }
                            else if (string.Equals(Confirmation, "N", StringComparison.OrdinalIgnoreCase))
                            {
                                delay.TextDelay("\n[Operación cancelada]");
                                ValidConfirmation = true;
                            }
                            else
                            {
                                Console.WriteLine("\nEntrada no válida. Ingrese S o N.");
                            }
                        }
                        delay.TextDelay("Presione una tecla para volver al menú");
                        Console.ReadKey();
                        break;
                    case "2":
                        loop = false;
                        ValidConfirmation = false;
                        delay.TextDelay("Ingrese el ID del DISTRIBUIDOR que desea actualizar:\n");
                        input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input))
                        {
                            ValidConfirmation = true;
                            delay.TextDelay("Entrada NULL no válida");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            id = Convert.ToInt32(input);
                        }
                        ShippersLogic ShippersLogic = new ShippersLogic();
                        Shipper ShipperToUpdate = ShippersLogic.Find(id);
                        if (ShipperToUpdate == null)
                        {
                            delay.TextDelay($"No se encontró el registro de ID {id}");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        delay.TextDelay($"Datos actuales del DISTRIBUIDOR seleccionado ==> Empresa: { ShipperToUpdate.CompanyName} - Teléfono: { ShipperToUpdate.Phone }\n");
                        delay.TextDelay("A continuación deberá ingresar los datos del DISTRIBUIDOR que desea actualizar:");
                        delay.TextDelay("Empresa:");
                        companyName = Console.ReadLine();
                        delay.TextDelay("Teléfono");
                        phone = Console.ReadLine();
                        while (!ValidConfirmation)
                        {
                            delay.TextDelay("\n¿Está seguro/a que los datos ingresados son correctos? S/N:");
                            Confirmation = Console.ReadLine();
                            if (string.Equals(Confirmation, "S", StringComparison.OrdinalIgnoreCase))
                            {
                                ShippersLogic.Update(new Shipper
                                {
                                    ShipperID = Convert.ToInt32(id),
                                    CompanyName = companyName,
                                    Phone = phone
                                });
                                ValidConfirmation = true;
                            }
                            else if (string.Equals(Confirmation, "N", StringComparison.OrdinalIgnoreCase))
                            {
                                delay.TextDelay("\n[Operación cancelada]");
                                ValidConfirmation = true;
                            }
                            else
                            {
                                Console.WriteLine("\nEntrada no válida. Ingrese S o N.");
                            }
                        }
                        delay.TextDelay("\nPresione una tecla para volver al menú");
                        Console.ReadKey();
                        break;
                    case "3":
                        loop = false;
                        ValidConfirmation = false;
                        delay.TextDelay("Ingrese el ID del PROVEEDOR que desea actualizar:\n");
                        input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input))
                        {
                            ValidConfirmation = true;
                            delay.TextDelay("Entrada NULL no válida");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            id = Convert.ToInt32(input);
                        }
                        SuppliersLogic SuppliersLogic = new SuppliersLogic();
                        Supplier SupplierToUpdate = SuppliersLogic.Find(id);
                        if (SupplierToUpdate == null)
                        {
                            delay.TextDelay($"No se encontró el registro de ID {id}");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        delay.TextDelay($"Datos actuales del PROVEEDOR seleccionado ==> Empresa: {SupplierToUpdate.CompanyName} - Teléfono: {SupplierToUpdate.Phone} - Web:{SupplierToUpdate.HomePage}\n");

                        delay.TextDelay("A continuación deberá ingresar los datos del PROVEEDOR que desea actualizar:");
                        delay.TextDelay("Empresa:");
                        companyName = Console.ReadLine();
                        delay.TextDelay("Teléfono: ");
                        phone = Console.ReadLine();
                        delay.TextDelay("Web: ");
                        web = Console.ReadLine();
                        while (!ValidConfirmation)
                        {
                            delay.TextDelay("\n¿Está seguro/a que los datos ingresados son correctos? S/N:");
                            Confirmation = Console.ReadLine();

                            if (string.Equals(Confirmation, "S", StringComparison.OrdinalIgnoreCase))
                            {
                                SuppliersLogic.Update(new Supplier
                                {
                                    SupplierID = Convert.ToInt32(id),
                                    CompanyName = companyName,
                                    Phone = phone,
                                    HomePage = web
                                });
                                ValidConfirmation = true;
                            }
                            else if (string.Equals(Confirmation, "N", StringComparison.OrdinalIgnoreCase))
                            {
                                delay.TextDelay("\n[Operación cancelada]");
                                ValidConfirmation = true;
                            }
                            else
                            {
                                Console.WriteLine("\nEntrada no válida. Ingrese S o N.");
                            }
                        }
                        delay.TextDelay("\nPresione una tecla para volver al menú");
                        Console.ReadKey();
                        break;
                    default:
                        delay.TextDelay("La opción seleccionada no es válida, por favor inténtelo nuevamente.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        public void ShowSubMenuDelete()
        {
            DelayOutput delay = new DelayOutput();
            bool loop = true;
            string input;
            while (loop)
            {
                Console.Clear();
                delay.TextDelay("Seleccione la tabla de la que quiera eliminar un registro:\n|");
                delay.TextDelay("└ 1 - Clientes");
                delay.TextDelay("└ 2 - Distribuidores");
                delay.TextDelay("└ 3 - Proveedores");
                delay.TextDelay("└ 0 - Inicio");

                switch (Console.ReadLine())
                {
                    case "0":
                        loop = false;
                        SetCurrentMenu("0");
                        break;
                    case "1":
                        loop = false;
                        ValidConfirmation = false;
                        string Confirmation = "N";
                        delay.TextDelay("Introduzca el ID del CLIENTE a eliminar:");
                        input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input))
                        {
                            ValidConfirmation = true;
                            delay.TextDelay("Entrada NULL no válida");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        CustomersLogic customersLogic = new CustomersLogic();
                        Customer CustomerToDelete = customersLogic.Find(input);
                        if (CustomerToDelete == null)
                        {
                            delay.TextDelay($"No se encontró el registro de ID {input}");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        delay.TextDelay($"Datos del CLIENTE seleccionado ==> Nombre: {CustomerToDelete.ContactName} - Contacto: {CustomerToDelete.ContactTitle} - Empresa: {CustomerToDelete.CompanyName}");
                        while (!ValidConfirmation)
                        {
                            delay.TextDelay("\n¿Está seguro/a que desea eliminar el cliente? S/N:");
                            Confirmation = Console.ReadLine();

                            if (string.Equals(Confirmation, "S", StringComparison.OrdinalIgnoreCase))
                            {
                                customersLogic.Delete(input);
                                ValidConfirmation = true;
                            }
                            else if (string.Equals(Confirmation, "N", StringComparison.OrdinalIgnoreCase))
                            {
                                delay.TextDelay("\n[Operación cancelada]");
                                ValidConfirmation = true;
                            }
                            else
                            {
                                Console.WriteLine("\nEntrada no válida. Ingrese S o N.");
                            }
                        }

                        delay.TextDelay("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "2":
                        loop = false;
                        ValidConfirmation = false;
                        delay.TextDelay("Introduzca el ID del DISTRIBUIDOR a eliminar:");
                        input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input))
                        {
                            ValidConfirmation = true;
                            delay.TextDelay("Entrada NULL no válida");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            id = Convert.ToInt32(input);
                        }
                        ShippersLogic ShippersLogic = new ShippersLogic();
                        Shipper ShipperToDelete = ShippersLogic.Find(id);
                        if (ShipperToDelete == null)
                        {
                            delay.TextDelay($"No se encontró el registro de ID {id}");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        delay.TextDelay($"Datos del CLIENTE seleccionado ==> Empresa: {ShipperToDelete.CompanyName} - Teléfono: {ShipperToDelete.Phone}");
                        while (!ValidConfirmation)
                        {
                            delay.TextDelay("\n¿Está seguro/a que desea eliminar el distribuidor? S/N:");
                            Confirmation = Console.ReadLine();

                            if (string.Equals(Confirmation, "S", StringComparison.OrdinalIgnoreCase))
                            {
                                ShippersLogic.Delete(id);
                                ValidConfirmation = true;
                            }
                            else if (string.Equals(Confirmation, "N", StringComparison.OrdinalIgnoreCase))
                            {
                                delay.TextDelay("\n[Operación cancelada]");
                                ValidConfirmation = true;
                            }
                            else
                            {
                                Console.WriteLine("\nEntrada no válida. Ingrese S o N.");
                            }
                        }
                        delay.TextDelay("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        loop = false;
                        ValidConfirmation = false;
                        delay.TextDelay("Introduzca el ID del PROVEEDOR a eliminar:");
                        id = Convert.ToInt32(Console.ReadLine());
                        input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input))
                        {
                            ValidConfirmation = true;
                            delay.TextDelay("Entrada NULL no válida");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            id = Convert.ToInt32(input);
                        }
                        SuppliersLogic SuppliersLogic = new SuppliersLogic();
                        Supplier SupplierToDelete = SuppliersLogic.Find(id);
                        if (SupplierToDelete == null)
                        {
                            delay.TextDelay($"No se encontró el registro de ID {id}");
                            delay.TextDelay("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                        }
                        delay.TextDelay($"Datos del PROVEEDOR seleccionado ==> Empresa: {SupplierToDelete.CompanyName} - Teléfono: {SupplierToDelete.Phone} - Web: {SupplierToDelete.HomePage}");
                        while (!ValidConfirmation)
                        {
                            delay.TextDelay("\n¿Está seguro/a de que desea eliminar el distribuidor? S/N");
                            Confirmation = Console.ReadLine();

                            if (string.Equals(Confirmation, "S", StringComparison.OrdinalIgnoreCase))
                            {
                                SuppliersLogic.Delete(id);
                                ValidConfirmation = true;
                            }
                            else if (string.Equals(Confirmation, "N", StringComparison.OrdinalIgnoreCase))
                            {
                                delay.TextDelay("\n[Operación cancelada]");
                                ValidConfirmation = true;
                            }
                            else
                            {
                                Console.WriteLine("\nEntrada no válida. Ingrese S o N.");
                            }
                        }
                        delay.TextDelay("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    default:
                        delay.TextDelay("\nLa opción seleccionada no es válida.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private void GoodBye()
        {
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
