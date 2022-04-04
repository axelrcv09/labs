using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;


namespace Demo5.Sopra.ConsoleApp1
{
    internal class Program
    {
        private static HttpClient http = new HttpClient();
        static void Main(string[] args)
        {
            GetStudent();
        }

        static void GeoLocationIP()
        {
            // GET http://ip-api.com/json/193.146.141.207

            // Instanciar el cliente HTTP
            var http = new HttpClient();

            // Definir la dirección Base (parte de la URL que se repite em todas las llamadas)
            http.BaseAddress = new Uri("http://ip-api.com/json/");

            // Definir cabeceras

            // Definir el cuerpo del mensaje

            // Llamada al microservicio (API Rest o HTTP-based) utilizando el método7verbo correspondiente
            // Método o Verbo: GET

            Console.Write("Dirección IP: ");
            string ip = Console.ReadLine();

            HttpResponseMessage response = http.GetAsync(ip).Result;
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Leer el contenido del body del mensaje (propiedad Content del mensaje de respuesta)
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Contenido en JSON:");
                Console.WriteLine(content);

                // Deserializar. Convertir de JSON a Objeto.
                var data1 = JsonConvert.DeserializeObject<InfoIP>(content);
                data1.Demo();
                //Console.WriteLine($"Registro: {data1.registro}" + Environment.NewLine);

                var data2 = JsonConvert.DeserializeObject<InfoIP2>(content);

                var data = JsonConvert.DeserializeObject<dynamic>(content);

                Console.WriteLine($"Datos de la dirección: {data.query} ");
                Console.WriteLine($"País: {data.country} ({data.countryCode})");
                Console.WriteLine($"Región: {data.regionName}");
                Console.WriteLine($"Ciudad: {data.zip} {data.city}");
                Console.WriteLine($"Proveedor: {data.isp}");
                Console.WriteLine($"Posición: {data.lat}, {data.lon}");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

        }

        static void ZipInfo()
        {
            // GET: http://api.zippopotam.us/es/28013

            var http = new HttpClient();

            http.BaseAddress = new Uri("http://api.zippopotam.us/es/");

            Console.Write("Código postal: ");
            string zip = Console.ReadLine();

            HttpResponseMessage response = http.GetAsync(zip).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<dynamic>(content);

                Console.WriteLine($"Código postal: {data["post code"]}");
                Console.WriteLine($"País: {data.country} - {data["country abbreviation"]}");
                foreach (var item in data.places)
                {
                    Console.WriteLine($" -  Lugar: {item["place name"]}");
                    Console.WriteLine($"    Estado: {item["state"]} - {item["state abbreviation"]}");
                    Console.WriteLine($"    Coordenadas: {item["longitude"]} - {item["latitude"]}");
                };
            }
            else
            {
                Console.Write($"Error: {response.StatusCode}");
            }

        }
        static void ZipInfo3()
        {
            // GET: http://api.zippopotam.us/es/28013

            var http = new HttpClient();

            http.BaseAddress = new Uri("http://api.zippopotam.us/es/");

            Console.Write("Código postal: ");
            var data = http.GetFromJsonAsync<ZipInfo>(Console.ReadLine()).Result; ;

            //HttpResponseMessage response = http.GetAsync(zip).Result;
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    string content = response.Content.ReadAsStringAsync().Result;

            //    var data = JsonConvert.DeserializeObject<dynamic>(content);

            //    Console.WriteLine($"Código postal: {data["post code"]}");
            //    Console.WriteLine($"País: {data.country} - {data["country abbreviation"]}");
            //    foreach (var item in data.places)
            //    {
            //        Console.WriteLine($" -  Lugar: {item["place name"]}");
            //        Console.WriteLine($"    Estado: {item["state"]} - {item["state abbreviation"]}");
            //        Console.WriteLine($"    Coordenadas: {item["longitude"]} - {item["latitude"]}");
            //    };
                //Console.WriteLine($"Lugar: {data.places[0].GetValue("place name")}");
                //Console.WriteLine($"Coordenadas: {data.places[0].GetValue("longitude")} - {data.places[0].GetValue("latitude")}");
                //Console.WriteLine($"Estado: {data.places[0].GetValue("state")} - {data.places[0].GetValue("state abbreviation")}");
        //    }
        //    else
        //    {
        //        Console.Write($"Error: {response.StatusCode}");
        //    }
        //}

        static void Eco()
        {

            //http.BaseAddress = new Uri("http://api.zippopotam.us/es/");

            //http.DefaultRequestHeaders.Clear();

            //http.DefaultRequestHeaders.Add("x-param-1", "D E M O");

            //http.DefaultRequestHeaders.Add("User-Agent", "Ejercicios Demo");
            ////http.DefaultRequestHeaders.Add("Content-Type", "application/json");
            //http.DefaultRequestHeaders.Add("Accept", "application/json");

            //http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //// Body

            //// Con objeto
            //var zip = new ZipInfo()
            //{
            //    PostalCode = "28014",
            //    Country = "Spain",
            //    CountryCode = "SP",
            //    Places = new List<PlaceZipInfo>()
            //    {
            //        new PlaceZipInfo() { nameof = "Madrid", WriteState = "Madrid", StateCode = "M"}
            //    }
            //};

            ////var content = new StringContent(JsonConvert.SerializeObject(zip), Encoding.UTF8, "application/json");

            //var zip2 = new
            //{
            //    Code = "28014",
            //    Pais = "Spain",
            //    CodigoISO = "SP",
            //    Referencia = 521,
            //    Sitios = new dynamic[]
            //    {
            //        new {Nombre = "Madrid", Comunidad = "Madrid", CodigoISO = "M"},
            //        new {Nombre = "Alcala ", Comunidad = "Madrid", CodigoISO = "M"}
            //    }
            //};

            //var content2 = new StringContent(JsonConvert.SerializeObject(zip2), Encoding.UTF8, "application/json");

            //// Send Request
            //var response = http.PostAsync("post?param1=demo&para2=Hola", content2).Result;

            //// Process Response
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    var responseBody = response.Content.ReadAsStringAsync().Result;
            //    Console.WriteLine(responseBody);
            //}
            //else Console.WriteLine($"Error: {response.StatusCode}");

            Console.ReadKey();
        }
       

    }
        static void GetStudent()
        {

            // Definir la dirección Base (parte de la URL que se repite em todas las llamadas)
            http.BaseAddress = new Uri("http://school.labs.com.es/api/students/");

            // Definir cabeceras

            // Definir el cuerpo del mensaje

            // Llamada al microservicio (API Rest o HTTP-based) utilizando el método/verbo correspondiente
            // Método o Verbo: GET

            Console.Write("Número del estudiante: ");
            string numeroEstudiante = Console.ReadLine();

            HttpResponseMessage response = http.GetAsync(numeroEstudiante).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Leer el contenido del body del mensaje (propiedad Content del mensaje de respuesta)
                string content = response.Content.ReadAsStringAsync().Result;

                // Deserializar. Convertir de JSON a Objeto.
                var data = JsonConvert.DeserializeObject<Student>(content);

                Console.WriteLine($"Nombre completo: {data.Firstname} {data.Lastname}");
                Console.WriteLine($"Id: {data.Id}");
                Console.WriteLine($"Fecha de nacimiento: {data.DateOfBirth}");
                Console.WriteLine($"Id Clase: {data.ClassId}");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

        }

        static void GetStudent2()
        {
            http.BaseAddress = new Uri("http://school.labs.com.es/api/students/");

            Console.Clear();
            Console.WriteLine("Id Estudiante: ");

            try
            {
                var data = http.GetFromJsonAsync<Student>(Console.ReadLine()).Result;
                if 
            }
        }
    }
}
