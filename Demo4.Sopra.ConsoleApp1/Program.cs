using System;
using System.Collections.Generic;

namespace Demo4.Sopra.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prueba<string> prueba = new Prueba<string>("Mensaje de Prueba");
            Console.WriteLine($"Valor: {prueba.Valor} - Número: {prueba.Numero}");
            prueba.Metodo();

            Prueba<int> prueba2 = new Prueba<int>(35);
            Console.WriteLine($"Valor: {prueba2.Valor} - Número: {prueba2.Numero}");
            prueba2.Metodo();

            Console.ReadKey();

            Gorila gorila = new Gorila() { Nombre = "Copito de Nieve", Familia = "Mamiferos", HorasDormir = 8};
            gorila.Mensaje();
            gorila.Descansar();

            Console.ReadKey();

            ListaExtendida<string> lista = new ListaExtendida<string>();
            lista.Add("Prueba");

            Demo demo = new Demo() { Nombre = "Hunday Tucson", Ruedas = "4", Tipo = "Gasolina" };
            Console.WriteLine($"{demo.NombreCompleto}");
            demo.Arrancar();

            Console.ReadKey();

            Coche coche = new Coche() { Nombre = "Hunday Tucson", Ruedas = "4", Tipo = "Gasolina" };
            coche.Arrancar();
            coche.Parar();

            Avion avion = new Avion() { Nombre = "Jumbo 747", Ruedas = "8" };
            avion.Arrancar();
            avion.Parar();
            avion.Despegar();
            avion.Aterrizar();

            Console.WriteLine(Environment.NewLine);

            //IVehiculo vehiculo = avion;
            //vehiculo.Arrancar();
            //vehiculo.Parar();

            Procesar(avion);
            Console.WriteLine(Environment.NewLine);
            Procesar(coche);

        }

        static void Procesar(IVehiculo vehiculo)
        {
            // Funcionalidad común
            vehiculo.Arrancar();
            vehiculo.Parar();

            // Funcionalidad especifica
            Console.WriteLine(vehiculo.GetType().Name);

            if (vehiculo.GetType() == typeof(Avion))
            {
                ((Avion)vehiculo).Despegar();
                ((Avion)vehiculo).Aterrizar();
            }

            if (vehiculo.GetType() == typeof(Coche))
            {
                Console.WriteLine($"Tipo: {((Coche)vehiculo).Tipo}");
            }
        }
    }

    class Prueba<T>
    {
        public int Numero { get; set; }
        public T Valor { get; set; }

        public Prueba()
        { }

        public void Metodo()
        {
            Console.WriteLine($"El tipo es {typeof(T).ToString()}");
            if (typeof(T) == typeof(string)) Console.WriteLine("Comprobado que es alfanumérico.");
        }

        public Prueba(T datos)
        {
            this.Valor = datos;
        }
    }

    interface IVehiculo
    {
        string Nombre { get; set; }
        string Ruedas { get; set; }
        void Arrancar();
        void Parar();
    }
    class Coche : IVehiculo
    {
        public string Nombre { get; set; }
        public string Ruedas { get; set; }
        public string Tipo { get; set; }

        public virtual void Arrancar()
        {
            Console.WriteLine($"Coche arrancando, de tipo {Tipo}.");
        }

        public void Parar()
        {
            Console.WriteLine($"Coche parando, de tipo {Tipo}.");
        }
        void IVehiculo.Arrancar()
        {
            Console.WriteLine("Vehiculo arrancando.");
        }

        void IVehiculo.Parar()
        {
            Console.WriteLine("Vehiculo parando.");
        }
    }
    class Avion : IVehiculo
    {
        public string Nombre { get; set; }
        public string Ruedas { get; set; }

        public void Arrancar()
        {
            Console.WriteLine("Avión arrancando.");
        }

        public void Parar()
        {
            Console.WriteLine("Avión parando.");
        }
        public void Despegar()
        {
            Console.WriteLine("Avión despegando.");
        }
        public void Aterrizar()
        {
            Console.WriteLine("Avión aterrizando.");
        }
    }

    class ListaExtendida<T> : List<T>
    {

    }

    class Demo : Coche
    {
        public string NombreCompleto { get => $"{Nombre}, de tipo {Tipo}"; }

        public override void Arrancar()
        {
            base.Arrancar();
            Console.WriteLine("Se ejecuta Arrancar de Demo.");
        }
    }
    sealed class Alumno
    { }
    abstract class Animal
    {
        protected int horasDormir = 0;
        public abstract int HorasDormir { get; set; }

        public string Nombre { get; set; }
        public string Familia { get; set; }

        public void Mensaje()
        {
            Console.WriteLine($"Soy {Nombre}, de la familia {Familia}.");
        }

        public abstract void Descansar();

    }

    class Gorila : Animal
    {
        public override int HorasDormir { get => horasDormir; set => horasDormir = value; }

        public override void Descansar()
        {
            Console.WriteLine($"{Nombre}, comenzando a dormir");
        }
    }
}
