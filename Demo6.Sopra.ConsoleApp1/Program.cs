using System;

namespace Demo6.Sopra.ConsoleApp1
{
    public delegate void DelDemo();

    public delegate void DelDemo2(int n, int m);

    public class AlumnoEventArgs
    {
        public DateTime Fecha { get; set; }
        public string NombreCompleto { get; set; }
    }

    public class Alumno
    {
        public delegate void DemoEventHandler(object sender, AlumnoEventArgs e);
        public event DemoEventHandler FichaCompleta;
        private string nombre;
        private string apellidos;
        public string Nombre 
        {
            get
            {
                return Nombre;
            }
            set
            {
                nombre = value;
                if (nombre != null && nombre != "")
                {
                    FichaCompleta?.Invoke(this,
                        new AlumnoEventArgs() { Fecha = DateTime.Now, NombreCompleto = $"{nombre} {apellidos}" });
                }
            }
        }
        public string Apellidos { get; set; }
        public string Edad { get; set; }
    }

    public class Alumno2
    { 
        public event EventHandler<string> FichaCompleta;
        private string nombre;
        private string apellidos;
        public string Nombre 
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                
            }
        }
        public string Apellidos 
        {
            get
            {
                return apellidos;
            }
            set
            {
                apellidos = value;
            } 
        }
        public string Edad { get; set; }
    }

    public struct Profesor
    {

    }

    public enum Demo 
    { 
        uno, dos, tres, cuatro
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Alumno alumno1 = new Alumno();

            alumno1.FichaCompleta += (sender, e) => 
            {
                Console.WriteLine($"La ficha se ha completado {e.Fecha}");
                Console.WriteLine($"Nombre: {e.NombreCompleto}");
            };

            //////////////////////////////////////////////////////////////////////

            DelDemo2 d1 = Suma;
            MetodoDemo(100, d1);

            DelDemo2 d2 = (x, y) =>
            {
                var resultado = x + 10 * y;
                Console.WriteLine(resultado);
            };

            MetodoDemo(100, d2);

            Console.WriteLine("");

            MetodoDemo(100, (n, m) => { Console.WriteLine($"Suma: {n + m}"); });

            Console.ReadKey();

            String mensaje = "";
            Alumno alumno = new Alumno();

            DelDemo delegado = Saludo;
            delegado();

            DelDemo delegado2 = () =>
            {
                Console.WriteLine("Hola Mundo!");
                Console.WriteLine("Método anónimo construido con una expresión lambda.");
            };
            delegado2 = Saludo;

            delegado2();

            DelDemo2 delegado3 = Suma;
            delegado3(10, 35);

            delegado3 = Multiplica;
            delegado3(10, 35);

            Console.ReadKey();
        }

        static void MetodoDemo(int n1, DelDemo2 funcion)
        {
            int n2 = 52;
            funcion(n1, n2);
        }

        static void Saludo()
        {
            Console.WriteLine("Hola Mundo!");
        }

        static string Saludo2()
        {
            return "Hola Mundo!";
        }

        static void Suma(int num1, int num2)
        {
            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
        }
        static void Multiplica(int num1, int num2)
        {
            Console.WriteLine($"{num1} x {num2} = {num1 * num2}");
        }

    }

    
}
