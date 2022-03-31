using System;

namespace Sopra.Labs.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MostrarTablaMultiplicar();
            //MostrarValores();
            //CalculaLetraDNI();
            CalcularValores();

        }

        static void MostrarTablaMultiplicar()
        {
            // Utilizando for
            string valor;
            int num;

            Console.WriteLine("Número: ");
            valor = Console.ReadLine();
            Int32.TryParse(valor, out num);
            Console.WriteLine($"Tabla de multiplicar de {num}");

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i*num);
            }

            Console.ReadKey();

            // Utilizando while
            string valor2;
            int num2;
            int contador;

            Console.WriteLine("Número: ");
            valor2 = Console.ReadLine();
            Int32.TryParse(valor, out num2);
            Console.WriteLine($"Tabla de multiplicar de {num2}");

            contador = 0;

            while (contador <= 10)
            {
                Console.WriteLine(num2*contador);
                contador++;
            }
        }

        static void MostrarValores()
        {
            // desde valor de inicio al valor final

            string valor, valor2, paso;
            int num, num2, nPaso;

            Console.Write("Número inicio: ");
            valor = Console.ReadLine();
            Int32.TryParse(valor, out num);
            Console.Write("Número fin: ");
            valor2 = Console.ReadLine();
            Int32.TryParse(valor2, out num2);
            Console.Write("Paso: ");
            paso = Console.ReadLine();
            Int32.TryParse(paso, out nPaso);

            if (num2 < num)
            {
                nPaso = -nPaso;
            }

            for (int i = num; i != num2; i = i + nPaso)
            {
                Console.WriteLine(i);
            }

        }

        static void CalcularValores()
        {
            // número de valores
            // almacenamos en un array
            // calculos, max, min, media, suma
            string posiciones, valor;
            int num, max;
            

            Console.Write("Número de posiciones: ");
            posiciones = Console.ReadLine();
            Int32.TryParse(posiciones, out int nPosiciones);
            int[] array = new int[nPosiciones];

            for (int i = 0; i < nPosiciones; i++)
            {
                Console.Write($"Introduzca un valor: ");
                valor = Console.ReadLine();
                int.TryParse(valor, out num);
                array[i] = num;
            }

            for(int i = 0; i < nPosiciones; i++)
            {
                if(array[i] > array[i - 1])
                {
                    max = array[i];
                }
            }


            Console.WriteLine(array);
        }

        static void CalculaLetraDNI()
        {
            // número % 23
            // posición de Array de las letras

            string dni;
            int number;
            int posicion;
            char[] letra = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

            Console.WriteLine("Número DNI: ");
            dni = Console.ReadLine();
            Int32.TryParse(dni, out number);
            posicion = number % 23;
            Console.WriteLine(posicion);
            Console.WriteLine($"La letra del DNI es: {letra[posicion]}");

              
        }
    }
}
