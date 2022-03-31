using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo2.Sopra.ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Calculos calculos = new Calculos() { Num1 = 10, Num2 = 0 };
                calculos.Dividir();
                Console.WriteLine($"Resultado: {calculos.Resultado}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Main --> Error: {e.Message}");
            }
        }
        static void Colecciones()
        {
            // Instanciar
            ArrayList colores = new ArrayList();

            // Limpiar, eliminar todos los elementos
            colores.Clear();

            // Añadir elementos
            colores.Add("azul");
            colores.Add("rojo");
            colores.Add("amarillo");
            colores.Add("96");
            colores.Add(new Calculos()); // Se puede añadir cualquir cosa porque no esta tipado

            var array = new string[] { "marrón", "verde", "naranja" };
            colores.AddRange(array);
            // Forma simplificada de las dos lineas anteriores
            colores.AddRange(new string[] { "marrón", "verde", "naranja" });

            colores.Add(array[1]);

            // Número de elementos
            Console.WriteLine($"Elementos: {colores.Count}"); // Count es lo mismo que length pero para colecciones

            // Recorrer el ArrayList
            foreach (var item in colores) Console.WriteLine($"item: {item}");

            Console.WriteLine("");
            Console.WriteLine(Environment.NewLine);

            for(int i = 0; i < colores.Count; i++) Console.WriteLine($"item: {colores[i]}");

            // Eliminar
            colores.Remove("verde");
            colores.Remove(3);
            colores.RemoveRange(2, 2); // Posición (incluida), número de elementos a eliminar 


            /////////////////////////////////////////////
            
            List<string> frutas = new List<string>();

            // Limpiar, eliminar todos los elementos
            frutas.Clear();

            // Añadir elementos
            frutas.Add("azul");
            frutas.Add("rojo");
            frutas.Add("amarillo");

            var array2 = new string[] { "limón", "manzana", "fresa" };
            frutas.AddRange(array2);
            // Forma simplificada de las dos lineas anteriores
            frutas.AddRange(new string[] { "limón", "manzana", "fresa" });

            frutas.Add(array2[1]);

            // Número de elementos
            Console.WriteLine($"Elementos: {frutas.Count}"); // Count es lo mismo que length pero para colecciones

            // Recorrer el ArrayList
            foreach (var item in frutas) Console.WriteLine($"item: {item}");

            Console.WriteLine("");
            Console.WriteLine(Environment.NewLine);

            for (int i = 0; i < frutas.Count; i++) Console.WriteLine($"item: {colores[i]}");

            // Eliminar
            frutas.Remove("limón");
            //frutas.Remove(1);
            frutas.RemoveRange(2, 2); // Posición (incluida), número de elementos a eliminar 

            //////////////////////////////////////////////////
            
            List<int> numeros = new List<int>();

            //////////////////////////////7777
            
            Dictionary<string, string> frutas2 = new Dictionary<string, string>();

            // Limpiar 
            frutas2.Clear();

            //Añadir elementos
        }
    }

    public class Calculos
    {

        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Resultado { get; set; }
        public void Suma()
        {
            Resultado = Num1 + Num2;
        }
        public void Resta()
        {
            Resultado = Num1 - Num2;   
        }
        public void Dividir()
        {
            try
            {
                Resultado = Num1 / Num2;
            }
            catch (DivideByZeroException e)
            {
                throw e;
                //Console.WriteLine("No se puede dividir entre cero. Revise los valores.");
                Console.WriteLine($"Error: {e.Message}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                Num1 = Num2 = 0;
                Resultado = 0;
                Console.WriteLine("Objeto Inicializado");
            }
        }
    }
}
