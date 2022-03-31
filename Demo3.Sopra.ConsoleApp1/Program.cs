using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Demo3.Sopra.ConsoleApp1.Models;

namespace Demo3.Sopra.ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Ejercicios31032022();
        }

        static void Ejercicios31032022()
        {

            var context = new ModelNorthwind();

            // Clientes de USA

            var clientesUSA = context.Customers
                .Where(r => r.Country == "USA")
                .OrderBy(r => r.City)
                .ToList();

            foreach (var cliente in clientesUSA)
            {
                Console.WriteLine($"Nombre del contacto: {cliente.ContactName}");
                Console.WriteLine($"Empresa: {cliente.CompanyName}"); 
                Console.WriteLine($"Región: {cliente.City} - {cliente.Country}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Proveedores (Suppliers) de BERLIN

            var proveedoresBerlin = context.Suppliers
                .Where(r => r.City == "Berlin")
                .OrderBy(r => r.CompanyName)
                .ToList();

            foreach (var cliente in proveedoresBerlin)
            {
                Console.WriteLine($"Nombre del contacto: {cliente.ContactName}");
                Console.WriteLine($"Empresa: {cliente.CompanyName}");
                Console.WriteLine($"Región: {cliente.City} - {cliente.Country}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Los empleados con ID 3, 5 y 8

            //int[] employeesIds = new int[] { 3, 5, 8 };

            //var empleados2 = context.Employees
            //    .Where(r => employeesIds.Contains(r.EmployeeID));

            var empleados = context.Employees
                .Where(r => (r.EmployeeID == 3) || (r.EmployeeID == 5) || (r.EmployeeID == 8))
                .ToList();

            foreach (var e in empleados)
            {
                Console.WriteLine($"Nombre del empleado: {e.FirstName} {e.LastName}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Productos con stock mayor de cero

            var productosStock = context.Products
                .Where(r => r.UnitsInStock > 0)
                .ToList();

            foreach (var i in productosStock)
            {
                Console.WriteLine($"Producto: {i.ProductName}");
                Console.WriteLine($"Cantidad en stock: {i.UnitsInStock}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Productos con stock mayor de cero de los proveedores con id 1, 3 y 5
            // Se puede hacer el mismo array que en el ejercicio anterior pero en este caso tiene que ser nulleable
            var productosStockProveedores = context.Products
                .Where(r => r.UnitsInStock > 0 && (r.SupplierID == 1) || (r.SupplierID == 3) || (r.SupplierID == 5))
                .ToList();

            foreach (var i in productosStock)
            {
                Console.WriteLine($"Producto: {i.ProductName}");
                Console.WriteLine($"Cantidad en stock: {i.UnitsInStock}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Productos precio mayor de 20 y menor de 90

            var productosStockRango = context.Products
                .Where(r => r.UnitPrice > 20 && r.UnitPrice < 90)
                .ToList();

            foreach (var i in productosStock)
            {
                Console.WriteLine($"Producto: {i.ProductName}");
                Console.WriteLine($"Cantidad en stock: {i.UnitsInStock}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Pedidos entre 01.01.97 y 15.07.97

            var pedidos97 = context.Orders
                .Where(r => (r.OrderDate >= new DateTime(1997, 01, 01) && r.OrderDate <= new DateTime(1997, 07, 15)))
                .ToList();

            foreach (var i in pedidos97)
            {
                Console.WriteLine($"ID Pedido: {i.OrderID}");
                Console.WriteLine($"Fecha de pedido: {i.OrderDate}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Pedidos del 97 registrado por los empleados con id 1, 3, 4 y 8

            var pedidos97Empleados = context.Orders
                .Where(r => (r.OrderDate.Value.Year == 97 
                        && ((r.EmployeeID == 1) || (r.EmployeeID == 3) || (r.EmployeeID == 4) || r.EmployeeID == 8)))
                .ToList();

            foreach (var i in pedidos97Empleados)
            {
                Console.WriteLine($"ID Pedido: {i.OrderID}");
                Console.WriteLine($"ID Empleado: {i.EmployeeID}");
                Console.WriteLine($"Fecha de pedido: {i.OrderDate}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Pedidos de abril del 96

            var pedidosAbril96 = context.Orders
                .Where(r => r.OrderDate.Value.Year == 96 && r.OrderDate.Value.Month == 4)
                .ToList();

            foreach (var i in pedidosAbril96)
            {
                Console.WriteLine($"ID Pedido: {i.OrderID}");
                Console.WriteLine($"Fecha de pedido: {i.OrderDate}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Pedidos del realizados los días uno de cada del año 98

            var pedidos98 = context.Orders
                .Where(r => r.OrderDate.Value.Year == 98 && r.OrderDate.Value.Day == 1)     // Los días que no haya pedido daría error
                .ToList();

            foreach (var i in pedidos98)
            {
                Console.WriteLine($"ID Pedido: {i.OrderID}");
                Console.WriteLine($"Fecha de pedido: {i.OrderDate}" + Environment.NewLine);
            }

            // Clientes que no tienen fax

            var clientesSinFax = context.Customers
                .Where(r => r.Fax == null)
                .ToList();

            foreach (var i in clientesSinFax)
            {
                Console.WriteLine($"Nombre contacto: {i.ContactName}");
                Console.WriteLine($"Nombre empresa: {i.CompanyName}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Los 10 productos más baratos

            var productosBaratos = context.Products
                .Select(r => new {r.ProductName, r.UnitPrice })
                .OrderBy(r => r.UnitPrice)
                .ToList();
            
            for(int i = 0; i < 10; i++)     // Mejor usar metodos take y skip
            {
                Console.WriteLine($"Producto y precio: {productosBaratos[i]}" + Environment.NewLine);
            }

            Console.ReadKey();

            // Los 10 productos más caros con stock

            // Empresas de la letra B de UK

            // Productos de la categoría 3 y 5

            // Valor total del stock
        }

        static void TrabjandoConEF()
        {
            // EF o EntityFrameworkCore (manejamos la base de datos como colecciones

            var context = new ModelNorthwind();

            // Consultas:

            var resultado = context.Products
                .Where(r => r.ProductName.Contains("Queso"))
                .ToList();

            foreach(var product in resultado) Console.WriteLine(product.ProductName);

            Console.WriteLine("FIN");
            Console.ReadKey();

            // Eliminar Datos:

            var clienteBorrar = context.Customers
                .Where(r => r.CustomerID == "DEMO2")
                .FirstOrDefault();

            if (clienteBorrar == null) Console.WriteLine("No existe el cliente DEMO2");
            else
            {
                context.Customers.Remove(clienteBorrar);
            }

            context.SaveChanges();
            Console.WriteLine("Cliente eliminado correctamente");

            Console.ReadKey();

            // Actualizar colecciones de datos:

            var clientes3 = context.Customers
                .Where(r => r.Country == "Spain")
                .OrderBy(r => r.City)
                .ToList();

            // clientes3[0].Country = "España"

            foreach (var i in clientes3)
            {
                i.Country = "España";
            };

            context.SaveChanges();

            Console.ReadKey();

            // Actualizar Datos:

            var cliente = context.Customers
                .Where(r => r.CustomerID == "DEMO2")
                .FirstOrDefault();

            if (cliente == null) Console.WriteLine("No existe el cliente DEMO2");
            else
            {
                cliente.Region = "Madrid";
                cliente.Fax = "800 800 800";
                cliente.Address = "Gran Vía, 32";
            }

            context.SaveChanges();

            // Insertar Datos:

            var nuevoCliente = new Customer()
            {
                CustomerID = "DEMO2",
                CompanyName = " Empresa Demo, SL",
                ContactName = "Borja Cabeza",
                ContactTitle = "Gerente",
                Address = " Calle Unos, SN",
                City = "Madrid",
                Country = "España",
                //Region = "Madrid",
                Phone = "900 100 100",
                //Fax = "900 100 101"
            };

            context.Customers.Add(nuevoCliente);
            context.SaveChanges();

            Console.WriteLine("Registro insertado correctamente");

            Console.ReadKey();

            // Consulta de Datos: SELECT * FROM dbo.Customers WHERE Country = 'Spain' ORDER BY City

            var clientes = context.Customers
                .Where(r => r.Country == "Spain")
                .OrderBy(r => r.City)
                .ToList();

            var clientes2 = from r in context.Customers
                            where r.Country == "Spain"
                            orderby r.City
                            select r;

            foreach(var cliente2 in clientes)
            {
                Console.WriteLine($"ID: {cliente.CustomerID}");
                Console.WriteLine($"Empresa: {cliente.CompanyName}");     // Cuidado porque si cambia la columna no saldría la información buscada
                Console.WriteLine($"Región: {cliente.City} - {cliente.Country}" + Environment.NewLine);
            }

        }

        static void TrabajandoConADONET()
        {
            // ADO.NET Access Data Object (manejamos la base de datos con comando de Transat-SQL)

            // Consulta de datos: SELECT * FROM dbo.Customers WHERE Country = 'Spain' ORDER BY City
            
            // Crear la cadena de conexión contra la base de datos
            var connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "LOCALHOST",        // Servidor de Base de datos, nombre ó IP
                InitialCatalog = "NORTHWIND",    // Nombre de la Base de datos
                UserID = "",                     // Usuario
                Password = "",                   // Contraseña del usuario
                IntegratedSecurity = true,       // true es Seguridad basada en Windows
                ConnectTimeout = 60
            };

            // Mostrar la cadena de conexión
            Console.WriteLine($"Connection String {connectionString.ToString()}");

            // Creamos un objeto conexión, que representa la conexión con la base de datos
            var connect = new SqlConnection()
            {
                ConnectionString = connectionString.ToString()
            };

            Console.WriteLine($"Estado: {connect.State}");
            connect.Open();
            Console.WriteLine($"Estado: {connect.State}");

            // Creamos el comando que ejecutaremos contra la base de datos
            var command = new SqlCommand()
            {
                Connection = connect,
                CommandText = "SELECT * FROM dbo.Customers WHERE Country = 'Spain' ORDER BY City"
            };
            
            // Ejecutar el comando y recibir la respuesta
            //int registros = command.ExecuteNonQuery();          // Comando no consultas INSERT, UPDATE, DELETE

            SqlDataReader reader = command.ExecuteReader();     //Comando tipo consulta SELECT

            if (reader.HasRows == false) Console.WriteLine("Registros no encontrados");
            else
            {
                while (reader.Read() == true)
                {
                    Console.WriteLine($"ID: {reader["CustomerID"]}");
                    Console.WriteLine($"Empresa: {reader.GetValue(1)}");     // Cuidado porque si cambia la columna no saldría la información buscada
                    Console.WriteLine($"País: {reader["Country"]}" + Environment.NewLine);
                }
            }

            // Cerrar conexiones y destruir variables
            reader.Close();
            command.Dispose();
            connect.Close();
            connect.Dispose();

        }

        /// <summary>
        /// Búsquedsa básicas utilizando LINQ
        /// </summary>
        static void BusquedasBasicas()
        {
            // SELECT campos o columnas o * FROM servidor.basededatos.esquema.tabla WHERE filtro ORDER BY ordenación

            // SELECT * FROM ListaProductos WHERE Precio > 2 ORDER BY Precio DESCENTE

            var r5a = DataLists.ListaProductos
                .Where(r => r.Precio > 2)
                .OrderByDescending(r => r.Precio)
                .Select(r => new {r.Descripcion, r.Precio})
                .ToList();

            var r5b = from r in DataLists.ListaProductos
                      where r.Precio > 2
                      orderby r.Precio descending
                      select new { r.Descripcion, r.Precio };

            foreach (var item in r5b) Console.WriteLine($"{item.Descripcion} {item.Precio}");

            Console.ReadKey();

            // SELECT * FROM ListaProductos WHERE Precio > 2 ORDER BY Precio DESCENTE

            var r4a = DataLists.ListaProductos
                .Where(r => r.Precio > 2)
                .OrderBy(r => r.Precio)
                      .ToList();

            var r4b = from r in DataLists.ListaProductos
                      where r.Precio > 2
                      orderby r.Precio descending
                      select r;

            foreach (var item in r4b) Console.WriteLine($"{item.Id}{item.Descripcion} {item.Precio}");

            Console.ReadKey();
            // SELECT * FROM ListaProductos WHERE Precio > 2 

            var r3a = DataLists.ListaProductos
                      .Where(r => r.Precio > 2)
                      .ToList();

            var r3b = from r in DataLists.ListaProductos
                      where r.Precio > 2
                      select r;

            foreach (var item in r3b) Console.WriteLine($"{item.Id}{item.Descripcion}");

            Console.ReadKey();
            // SELECT Id, Descripcion, Precio FROM ListaProductos
            // SELECT * FROM ListaProductos

            var r1a = DataLists.ListaProductos.AsEnumerable();
            var r2a = DataLists.ListaProductos.ToList();

            var r1b = from r in DataLists.ListaProductos 
                      select r;

            var r2b= (from r in DataLists.ListaProductos
                  select r).ToList();

            foreach(var item in r2b) Console.WriteLine($"{item.Id}{item.Descripcion}");

            foreach(var item in r2a)
            {
                
            }

        }

        static void BusquedasEjercicio()
        {
            // Clientes nacidos entre 1980 y 1990

            var r1e = DataLists.ListaClientes
                .Where(r => r.FechaNac.Year >= 1980 && r.FechaNac.Year <= 1990)
                .OrderBy(r => r.FechaNac.Year)
                .Select(r => r.Nombre)
                .ToList();

            foreach (var item in r1e) Console.WriteLine($"{item}");
            Console.ReadKey();

            // Clientes mayores de 25 años

            DateTime hoy = new DateTime(2022, 03, 30);

            var r2e = DataLists.ListaClientes
                .Where(r => (r.FechaNac.AddYears(25)) < hoy)
                .Select(r => new {r.FechaNac, r.Nombre})
                .ToList();

            foreach (var item in r2e) Console.WriteLine($"{item.Nombre} {item.FechaNac}");
            Console.ReadKey();

            // Producto con el precio más alto

            var r3e = DataLists.ListaProductos
                .Select(r => r.Precio)
                .Max();

            Console.WriteLine(r3e);
            Console.ReadKey();

            // Precio medio de todos los productos

            var r4e = DataLists.ListaProductos
                .Select(r => r.Precio)
                .Average();

            Console.WriteLine(r4e);
            Console.ReadKey();


            // Productos con un precio inferior a la media

            var r5e = DataLists.ListaProductos
                .Where(r => r.Precio < r4e)
                .Select(r => new { r.Descripcion, r.Precio } )
                .ToList();

            foreach(var item in r5e) Console.WriteLine($"{item.Descripcion} {item.Precio}");
            Console.ReadKey();





        }
    }

    /// <summary>
    /// Representa el Objeto Cliente
    /// </summary>
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
    }

    /// <summary>
    /// Representa el Objeto Producto
    /// </summary>
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    }

    /// <summary>
    /// Representa el Objeto Pedido
    /// </summary>
    public class Pedido
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaPedido { get; set; }
    }

    /// <summary>
    /// Representa el Objeto Linea de Pedido
    /// </summary>
    public class LineaPedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }

    /// <summary>
    /// Representa una Base de datos en memoria utilizando LIST
    /// </summary>
    public static class DataLists
    {
        private static List<Cliente> _listaClientes = new List<Cliente>() {
            new Cliente { Id = 1,   Nombre = "Carlos Gonzalez Rodriguez",   FechaNac = new DateTime(1980, 10, 10) },
            new Cliente { Id = 2,   Nombre = "Luis Gomez Fernandez",        FechaNac = new DateTime(1961, 4, 20) },
            new Cliente { Id = 3,   Nombre = "Ana Lopez Diaz ",             FechaNac = new DateTime(1947, 1, 15) },
            new Cliente { Id = 4,   Nombre = "Fernando Martinez Perez",     FechaNac = new DateTime(1981, 8, 5) },
            new Cliente { Id = 5,   Nombre = "Lucia Garcia Sanchez",        FechaNac = new DateTime(1973, 11, 3) }
        };

        private static List<Producto> _listaProductos = new List<Producto>()
        {
            new Producto { Id = 1,      Descripcion = "Boligrafo",          Precio = 0.35f },
            new Producto { Id = 2,      Descripcion = "Cuaderno grande",    Precio = 1.5f },
            new Producto { Id = 3,      Descripcion = "Cuaderno pequeño",   Precio = 1 },
            new Producto { Id = 4,      Descripcion = "Folios 500 uds.",    Precio = 3.55f },
            new Producto { Id = 5,      Descripcion = "Grapadora",          Precio = 5.25f },
            new Producto { Id = 6,      Descripcion = "Tijeras",            Precio = 2 },
            new Producto { Id = 7,      Descripcion = "Cinta adhesiva",     Precio = 1.10f },
            new Producto { Id = 8,      Descripcion = "Rotulador",          Precio = 0.75f },
            new Producto { Id = 9,      Descripcion = "Mochila escolar",    Precio = 12.90f },
            new Producto { Id = 10,     Descripcion = "Pegamento barra",    Precio = 1.15f },
            new Producto { Id = 11,     Descripcion = "Lapicero",           Precio = 0.55f },
            new Producto { Id = 12,     Descripcion = "Grapas",             Precio = 0.90f }
        };

        private static List<Pedido> _listaPedidos = new List<Pedido>()
        {
            new Pedido { Id = 1,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 1) },
            new Pedido { Id = 2,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 8) },
            new Pedido { Id = 3,     IdCliente = 1,  FechaPedido = new DateTime(2013, 10, 12) },
            new Pedido { Id = 4,     IdCliente = 1,  FechaPedido = new DateTime(2013, 11, 5) },
            new Pedido { Id = 5,     IdCliente = 2,  FechaPedido = new DateTime(2013, 10, 4) },
            new Pedido { Id = 6,     IdCliente = 3,  FechaPedido = new DateTime(2013, 7, 9) },
            new Pedido { Id = 7,     IdCliente = 3,  FechaPedido = new DateTime(2013, 10, 1) },
            new Pedido { Id = 8,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 8) },
            new Pedido { Id = 9,     IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 22) },
            new Pedido { Id = 10,    IdCliente = 3,  FechaPedido = new DateTime(2013, 11, 29) },
            new Pedido { Id = 11,    IdCliente = 4,  FechaPedido = new DateTime(2013, 10, 19) },
            new Pedido { Id = 12,    IdCliente = 4,  FechaPedido = new DateTime(2013, 11, 11) }
        };

        private static List<LineaPedido> _listaLineasPedido = new List<LineaPedido>()
        {
            new LineaPedido() { Id = 1,  IdPedido = 1,  IdProducto = 1,     Cantidad = 9 },
            new LineaPedido() { Id = 2,  IdPedido = 1,  IdProducto = 3,     Cantidad = 7 },
            new LineaPedido() { Id = 3,  IdPedido = 1,  IdProducto = 5,     Cantidad = 2 },
            new LineaPedido() { Id = 4,  IdPedido = 1,  IdProducto = 7,     Cantidad = 2 },
            new LineaPedido() { Id = 5,  IdPedido = 2,  IdProducto = 9,     Cantidad = 1 },
            new LineaPedido() { Id = 6,  IdPedido = 2,  IdProducto = 11,    Cantidad = 15 },
            new LineaPedido() { Id = 7,  IdPedido = 3,  IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 8,  IdPedido = 3,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 9,  IdPedido = 4,  IdProducto = 2,     Cantidad = 3 },
            new LineaPedido() { Id = 10, IdPedido = 5,  IdProducto = 4,     Cantidad = 2 },
            new LineaPedido() { Id = 11, IdPedido = 6,  IdProducto = 1,     Cantidad = 20 },
            new LineaPedido() { Id = 12, IdPedido = 6,  IdProducto = 2,     Cantidad = 7 },
            new LineaPedido() { Id = 13, IdPedido = 7,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 14, IdPedido = 7,  IdProducto = 2,     Cantidad = 10 },
            new LineaPedido() { Id = 15, IdPedido = 7,  IdProducto = 11,    Cantidad = 2 },
            new LineaPedido() { Id = 16, IdPedido = 8,  IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 17, IdPedido = 8,  IdProducto = 3,     Cantidad = 9 },
            new LineaPedido() { Id = 18, IdPedido = 9,  IdProducto = 5,     Cantidad = 11 },
            new LineaPedido() { Id = 19, IdPedido = 9,  IdProducto = 6,     Cantidad = 9 },
            new LineaPedido() { Id = 20, IdPedido = 9,  IdProducto = 1,     Cantidad = 4 },
            new LineaPedido() { Id = 21, IdPedido = 10, IdProducto = 2,     Cantidad = 7 },
            new LineaPedido() { Id = 22, IdPedido = 10, IdProducto = 3,     Cantidad = 2 },
            new LineaPedido() { Id = 23, IdPedido = 10, IdProducto = 11,    Cantidad = 10 },
            new LineaPedido() { Id = 24, IdPedido = 11, IdProducto = 12,    Cantidad = 2 },
            new LineaPedido() { Id = 25, IdPedido = 12, IdProducto = 1,     Cantidad = 20 }
        };

        // Propiedades de los elementos privados
        public static List<Cliente> ListaClientes { get { return _listaClientes; } }
        public static List<Producto> ListaProductos { get { return _listaProductos; } }
        public static List<Pedido> ListaPedidos { get { return _listaPedidos; } }
        public static List<LineaPedido> ListaLineasPedido { get { return _listaLineasPedido; } }

    }

}
