using System;
//using Escuela;

namespace Demo.Sopra.ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
//            Alumno a3 = new Alumno();
//            a3.Cifrar("datos");
//            a3.Cifrar2("datos", algoritmo: "RDF3569");
//            a3.DiaTutoria = Dia.Miercoles;

//            Console.WriteLine($"Tutoria: { a3.DiaTutoria} - { (short)a3.DiaTutoria }");

//            //////////////////////////////////////////
//            int num = 10;

//            Console.WriteLine($"{num}");
//            //TransformarNumero(ref num);
//            Console.WriteLine($"{num}");

//            Console.ReadLine();

//            Alumno a1 = new Alumno() { nombre = "Ana", apellidos1 = "García" };
//            Alumno2 a2 = new Alumno2() { nombre = "Ana", apellidos1 = "García" };

//            Alumno[] alumnosDemo = { a1, a1, a1, a1, a1 };
//            alumnosDemo[2].nombre = "Borja";
//            foreach (var item in alumnosDemo) Console.WriteLine(item.nombre);

//            Alumno[] alumnosDemos2 =
//            {
//                new Alumno() { nombre ="Ana", apellidos1 = "García"},
//                new Alumno() { nombre ="Ana", apellidos1 = "García"},
//                new Alumno() { nombre ="Ana", apellidos1 = "García"},
//                new Alumno() { nombre ="Ana", apellidos1 = "García"},
//                new Alumno() { nombre ="Ana", apellidos1 = "García"},
//            };
//            alumnosDemos2[3].nombre = "Borja";


//            Console.ReadKey();

//            Console.WriteLine($"{a1.nombre} {a1.apellidos1}");
//            Transformar(a1);
//            Console.WriteLine($"{a1.nombre} {a1.apellidos1}");

//            Console.WriteLine($"{a2.nombre} {a2.apellidos1}");
//            Transformar(a2);
//            Console.WriteLine($"{a2.nombre} {a2.apellidos1}");


//            Console.ReadKey();

//            ////////////////////////////////////////////////////////////////////////////
//            int[] numeros = new int[10]; // Array de 10 elementos, todos 0
//            numeros[8] = 10;

//            int[] numeros2 = { 10, 5, 65, 2543, 60, 1234 };
//            Array.Resize(ref numeros2, 20);

//            Alumno[] alumnos = new Alumno[20];
//            alumnos[0] = new Alumno() { nombre = "Julian", apellidos1 = "Sanz" };

//            Alumno[] alumno2 =
//            {
//                new Alumno() { nombre = "Carlos", apellidos1 = "Cabeza"},
//                new Alumno() { nombre = "Anne", apellidos1 = "Fernández"},
//                new Alumno() { nombre = "José", apellidos1 = "de la Torre"},
//            };

//            alumno2[1].nombre = "Ana"; // Cambiar valor del nombre del segundo alumno en el array alumno2

//            Console.WriteLine($"Tamaño: {numeros2.Length}");

//            for(int i = 0; i < numeros2.Length; i++)
//            {
//                Console.WriteLine($"Posición: {i} - Valor: {numeros2[i]}");
//            }

//            foreach (int i in numeros2)
//            {
//                Console.WriteLine(i);
//            }

//            Console.ReadLine();

//            /////////////////////////////////////////////////////////////////////////7

//            string str1 = null;
//            Alumno alumno6 = null;

//            int n1 = 10;
//            int? n2 = null;

//            int r1 = 0;

//            r1 = n1;
//            r1 = Convert.ToInt32(n2);
//            r1 = (n2 == null) ? 0 : Convert.ToInt32(n2);
//            r1 = Convert.ToInt32(n2 ?? 0);



//            ///////////////////////////////////////////////////////////////////////////77
//            byte num1 = 15;             // 8 bits
//            int num2 = 1500;            // 32 bits
//            System.Int32 c1 = 1500;
//            string num3 = "DD 42";

//            Console.WriteLine($"N1: {num1} - N2: {num2}");

//            // Conversión Implicita
//            num2 = num1;

//            // num1 = num2;     // receptor menor tamaño en bits

//            // Conversión Explícita
//            num1 = 15;
//            num2 = 1500;

//            num1 = (byte)num2;


//            // Conversión Explícita con el objeto CONVERT
//            //num1 = Convert.ToByte(num2);
//            //num1 = Convert.ToByte(num3);


//            // Conversión Explícita, método PARSE
//            //num1 = byte.Parse(num3);


//            // Conversión Explícita, método TRYPARSE
//            bool result = byte.TryParse(num3, out num1);

//            Console.WriteLine(result); 
//            Console.WriteLine($"N1: {num1} - N2: {num2}");

//            var num4 = byte.TryParse(num3, out _);
//            Console.WriteLine($"N4: {num1}");



//            Console.ReadKey();
//            Console.Clear();


//            int a = 10;
//            int b, c = 20;
//            int d;

//            string n = "hola";

//            Alumno alumno;
//            Alumno alumno1 = new Alumno();
//            alumno1.nombre = "Juan";
//            alumno1.apellidos1 = "Sánchez";
//            alumno1.apellidos2 = "Sanz";
//            alumno1.edad = 25;

//            Console.WriteLine($"{ alumno1.nombre} { alumno1.apellidos1}");


//            //Alumno alumno2 = new Alumno() { nombre = "Carlos", apellidos1 = "Sanz", edad = 27 };
//            //Console.WriteLine($"{ alumno2.nombre} { alumno2.apellidos1}");

//            var alumno3 = new Alumno() { nombre = "Carlos", apellidos1 = "Sanz", edad = 27 };
//            Console.WriteLine($"{ alumno3.nombre} { alumno3.apellidos1}");
//            Console.WriteLine($"{ alumno3.GetType()}");

//            Object alumno4 = new Alumno() { nombre = "Carlos", apellidos1 = "Sanz", edad = 27 };
//            //Console.WriteLine($"{ alumno4.nombre} { alumno4.apellidos1}");

//            dynamic alumno5 = new Alumno() { nombre = "Carlos", apellidos1 = "Sanz", edad = 27 };
//            Console.WriteLine($"{ alumno5.nombre} { alumno5.apellidos1}");

//            Console.ReadKey();

//        }

//        static void Transformar(Alumno alum)
//        {
//            alum.nombre = "Borja";
//            alum.apellidos1 = "Cabeza";
//        }

//        static void Transformar(Alumno2 alum)
//        {
//            alum.nombre = "Borja";
//            alum.apellidos1 = "Cabeza";
//        }

//        static void Transformar(ref Alumno2 alum)
//        {
//            alum.nombre = "Borja";
//            alum.apellidos1 = "Cabeza";
//        }
//        static void TransformarNumero(out int a)
//        {
//            a = 5000;
        }
    }
}


//namespace Escuela
//{

//    public enum Dia { Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo};


//    // Variables de bloque sin modificador de acceso
//    // Variables de objetos con modificador de acceso
//    // Tipo de dato:             Alumno;
//    // Nombre de la variable:    alumno;
//    // Inicializar:              new Alumno();

//    public class Alumno
//    {
//        private Dia Tutoria;

//        public Dia DiaTutoria
//        {
//            get { return Tutoria; }
//            set { Dia Tutoria = value; }
//        }


//        //private string nombre;
//        //private string apellidos1;
//        public string Nombre { get; set; }
//        public string Apellidos1 { get; set; }

//        private string apellidos2;
//        public string Apellidos2
//        {
//            get
//            {
//                return apellidos2;
//            }
//            set
//            {
//                apellidos2 = value;
//            }
//        }

//        private int edad;
//        public int Edad
//        {
//            get
//            {
//                if (edad == 0) return 0;
//                else return edad;
//            }
//            set
//            {
//                if (value < 0) edad = 0;
//                else edad = value;
//            }
//        }

//        public string NombreCompleto // Solo lectura
//        {
//            get
//            {
//                return $"{Nombre} {Apellidos1} {apellidos2}");
//            }
//        }

//        private int demo;
//        public int Demo
//        {
//            set
//            {
//                demo = value;
//            }
//        }
//        public void MetodoDemo()
//        {

//        }

//        public int MetodoDemoDos()
//        {
//            return 0;   
//        }
//        public void Cifrar(string datos, string clave, string algoritmo)
//        {
//            // Lógica del cifrado
//        }
//        public void Cifrar(string datos, string clave)
//        {

//        }
//        public void Cifrar(string datos)
//        {
//            Cifrar(datos, "claveDefault", "RSA3452");
//        }

//        public void Cifrar2(string datos, string clave = "claveDefault", string algoritmo = "RSA3452")
//        {
//            // Lógica del cifrado
//        }

//        public Alumno()
//        {
//            nombre = "";
//            apellidos1 = "";
//            apellidos2 = "";
//            edad = 0;
//        }

//        public Alumno(string nombre, string apellidos1)
//        {
//            this.nombre=nombre;
//            this.apellidos1 = apellidos1;
//            apellidos2=apellidos1; 
//            edad = 0;
//        }

        
//    }

//    public struct Alumno2
//    {
//        public string nombre;
//        public string apellidos1;
//        public string apellidos2;
//        public int edad;
//    }
//}

