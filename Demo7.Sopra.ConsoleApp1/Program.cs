using System;
using System.Threading;
using System.Threading.Tasks;
using Demo3.Sopra.ConsoleApp1;
using System.Linq;
using Demo3.Sopra.ConsoleApp1.Models;

namespace Demo7.Sopra.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INICIO MAIN");
            DemoAsync();
            Console.WriteLine("FIN MAIN");
        }

        static void Test()
        {
            Console.WriteLine($"Método Test");
        }

        static void Test2(string data)
        {
            Console.WriteLine($"Método Test2: {data}");
        }

        static int Test3(CancellationToken token)
        {
            int result = 0;
            while (true)
            {
                result++;
                if (token.IsCancellationRequested) return result;
            }
        }

        static void Tareas()
        {
            Task tarea1 = new Task(new Action(Test));

            Task tarea2 = new Task(delegate
            {
                Console.WriteLine($"Método Anónimo creado por un delegado");
            });

            Task tarea3 = new Task(() =>
            {
                Console.WriteLine($"Método Anónimo creado por una lambda");
            });

            Task tarea4 = new Task(() => Test());

            Task tarea5 = Task.Run(() =>
            {
                Console.WriteLine($"Método Anónimo, tarea 5.");
            });

            Task<string> tarea6 = Task<string>.Run(() =>
            {
                Thread.Sleep(3000);
                return $"Método Anónimo, tarea 6.";
            });

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            Task<int> tarea7 = Task<int>.Run(() =>
            {
                return Test3(ct);
            });

            Console.WriteLine($"Estado 1: {tarea1.Status}");
            Console.WriteLine($"Estado 7: {tarea7.Status}");

            tarea1.Start();
            tarea2.Start();

            Console.WriteLine($"Estado 1: {tarea1.Status}");
            Console.WriteLine($"Estado 7: {tarea7.Status}");

            //tarea6.Wait();
            //tarea6.Wait(2000);
            // Console.WriteLine(tarea6.Result); // Result espera a que la tarea finalice, es como un wait.


            //Task[] tareas = { tarea1, tarea2, tarea6 };
            //Task.WaitAll(tareas);
            //Task.WaitAll(tareas, 1000);
            //Task.WaitAny(tareas);
            //Task.WaitAny(tareas, 2000);

            tarea3.Start();
            tarea4.Start();

            Parallel.Invoke(
                () => Test(),
                () => Test(),
                () => Test2("demo"),
                () => { Console.WriteLine("Método ejecutando en paralelo"); }
                );

            cts.Cancel();
            Console.WriteLine(tarea7.Result);

            Console.WriteLine($"Estado 1: {tarea1.Status}");
            Console.WriteLine($"Estado 7: {tarea7.Status}");
        }

        static void Calculos()
        {
            double[] array = new double[50000000];

            var f1 = DateTime.Now;
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = Math.Sqrt(i);
            }
            var f2 = DateTime.Now;
            Parallel.For(1, 50000000 - 1, (i) =>
            {
                array[i] = Math.Sqrt(i);
            });
            var f3 = DateTime.Now;

            Console.WriteLine($"FOR -> {f2.Subtract(f1).TotalMilliseconds} ms.");
            Console.WriteLine($"FOR PARALLEL -> {f3.Subtract(f2).TotalMilliseconds}");
        }

        static void Linq()
        {
            var context = new ModelNorthwind();

            var f1 = DateTime.Now;
            var clientes = context.Customers
                .Where(r => r.Country == "USA")
                .ToList();

            var f2 = DateTime.Now;
            var clientes2 = context.Customers
                .AsParallel()
                .Where(r => r.Country == "USA")
                .ToList();

            var f3 = DateTime.Now;

            foreach (var item in clientes) Console.WriteLine($"{item.CustomerID} {item.CompanyName}");
            Console.WriteLine("");
            foreach (var item in clientes2) Console.WriteLine($"{item.CustomerID} {item.CompanyName}");
        }

        static void ForEach()
        {
            var context = new ModelNorthwind();

            var clientes = context.Customers
                .Where(r => r.Country == "USA")
                .ToList();

            foreach (var item in clientes) Console.WriteLine($"{item.CustomerID} {item.CompanyName}");
            Console.WriteLine("");
            Parallel.ForEach(clientes, item => Console.WriteLine($"{item.CustomerID} {item.CompanyName}"));

            var f1 = DateTime.Now;
            foreach (var item in clientes)
            {
                item.City = "";
                item.Country = "";
            }
            var f2 = DateTime.Now;

            clientes = context.Customers
                .Where(r => r.Country == "USA")
                .ToList();
        }

        static async void DemoAsync()
        {
            Console.WriteLine("INICIO DEMO");
            var calculos = new Calculos();

            //calculos.CalcularSQRAsync();
            //for (var i = 49000000; i < 49000011; i++) Console.WriteLine(calculos.Array[i]);

            calculos.FinCalculos += (sender, args) =>
            {
                for (var i = 49000000; i < 49000011; i++) Console.WriteLine(((Calculos)sender).Array[i]);
            };
            //calculos.CalcularSQRAsync2();

            Console.WriteLine("FIN DEMO");

        }
    }
    public class Calculos
    {
        private double[] array = new double[50000000];

        public event EventHandler<string> FinCalculos;

        public double[] Array
        {
            get { return array; }
            set { array = value; }
        }

        public bool CalcularSQR()
        {
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = Math.Sqrt(i);
            }
            return true;
        }

        public Task<bool> CalcularSQRAsync()
        {
            return Task<bool>.Run(() =>
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        array[i] = Math.Sqrt(i);
                    }
                    Console.WriteLine("FIN DEL CALCULO");

                    return true;
                });
        }

        public Task<bool> CalcularSQRAsync2()
        {
            return Task<bool>.Run(() =>
            {
                for (int i = 1; i < array.Length; i++)
                {
                    array[i] = Math.Sqrt(i);
                }

                FinCalculos?.Invoke(this, DateTime.Now.ToString("dd-MM-yyyy HH:MM"));

                return true;
            });
        }
    }
}
