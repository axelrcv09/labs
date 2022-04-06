using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace Demo5.Sopra.ConsoleApp1
{
    internal class Program
    {
        private static HttpClient http = new HttpClient();
        static void Main(string[] args)
        {
            EjercicioParking();
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
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
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

                //Console.ReadKey();
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

        }
        static void PostStudent()
        {
            // Crear una instancia del Student
            // Rellenamos con datos recogidos

            http.BaseAddress = new Uri("http://school.labs.com.es/api/students/");

            // Body

            // Con objeto
            var student = new Student()
            {
                Firstname = "Axel",
                Lastname = "Vallet",
                DateOfBirth = new DateTime(1998, 10, 26),
                ClassId = 1,
            };

            var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");

            // Send request

            var response = http.PostAsync("", content).Result;

            // Process response

            if (response.StatusCode == HttpStatusCode.Created)
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseBody);
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }
        static void UpdateStudent()
        {
            http.BaseAddress = new Uri("http://school.labs.com.es/api/students/");

            Console.Write("Id del estudiante: ");
            string numeroEstudiante = Console.ReadLine();

            HttpResponseMessage response = http.GetAsync(numeroEstudiante).Result;
            if (response.IsSuccessStatusCode)
            {
                // Leer el contenido del body del mensaje (propiedad Content del mensaje de respuesta)
                string content = response.Content.ReadAsStringAsync().Result;

                // Deserializar. Convertir de JSON a Objeto.
                var data = JsonConvert.DeserializeObject<Student>(content);

                Console.WriteLine($"Nombre completo: {data.Firstname} {data.Lastname}");
                Console.WriteLine($"Id: {data.Id}");
                Console.WriteLine($"Fecha de nacimiento: {data.DateOfBirth}");
                Console.WriteLine($"Id Clase: {data.ClassId}");

                // Modificaciones

                Console.Write("Modificar nombre: ");
                data.Firstname = Console.ReadLine();

                Console.Write("Modificar apellido: ");
                data.Lastname = Console.ReadLine();

                Console.WriteLine("Modificar fecha de nacimiento: ");
                string fechaNacimiento = Console.ReadLine();
                DateTime.TryParse(fechaNacimiento, out DateTime dateOfBirth);
                data.DateOfBirth = dateOfBirth;

                Console.Write("Modificar clase: ");
                var lectura = Console.ReadLine();
                int.TryParse(lectura, out int idclase);
                data.ClassId = idclase;

                var contentModificado = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                HttpResponseMessage response2 = http.PutAsync(numeroEstudiante, contentModificado).Result;
                if (response2.IsSuccessStatusCode) Console.WriteLine("Estudiante modificado correctamente.");
                else Console.WriteLine($"Error: {response2.StatusCode}");

            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }


        }
        static void DeleteStudent()
        {
            http.BaseAddress = new Uri("http://school.labs.com.es/api/students/");

            Console.Write("Id del estudiante: ");
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

            Console.Write("¿Quiere borrar el estudiante? SI / NO ---> ");
            string respuesta = Console.ReadLine();

            if (respuesta == "SI")
            {
                HttpResponseMessage response2 = http.DeleteAsync(numeroEstudiante).Result;
                if (response2.IsSuccessStatusCode) Console.WriteLine("Estudiante borrado");
                else Console.WriteLine($"Error: {response2.StatusCode}");
            }
        }
        static void Ejercicio()
        {
            http.BaseAddress = new Uri("https://openapi.emtmadrid.es/v2/");

            http.DefaultRequestHeaders.Clear();

            //Console.WriteLine("Introducir X-ClientId: ");
            //string xClientId = Console.ReadLine();
            //Console.WriteLine("Introducir passKey: ");
            //string passKey = Console.ReadLine();

            http.DefaultRequestHeaders.Add("X-ClientId", "d84d5b34-3778-43cd-a491-17a5618bc49c");
            http.DefaultRequestHeaders.Add("passKey", "B6DC937C60C5757D53B3F9CB4CFF89EBA6E39770222C31215478A4547A95AA10B18CAF131121DB75836FE944DE87C5660D3A49C6121B93A9DF159985F85402A5");

            HttpResponseMessage response = http.GetAsync("mobilitylabs/user/login/").Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                string token = data.data[0].accessToken;

                //Console.WriteLine($"Token: {token}");

                // Headers

                http.DefaultRequestHeaders.Clear();
                http.DefaultRequestHeaders.Add("accessToken", token);

                // Body

                var body = new Body()
                {
                    cultureInfo = "ES",
                    Text_StopRequired_YN = "Y",
                    Text_EstimationsRequired_YN = "Y",
                    Text_IncidencesRequired_YN = "N",
                    DateTime_Referenced_Incidencies_YYYYMMDD = DateTime.Now.ToString("yyyyMMdd")
                };

                Console.Write("Número de la parada: ");
                var numParada = Console.ReadLine();

                var content2 = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                // Send request

                var response2 = http.PostAsync($"transport/busemtmad/stops/{numParada}/arrives/", content2).Result;

                if (response2.IsSuccessStatusCode)
                {
                    var responseBody = response2.Content.ReadAsStringAsync().Result;

                    var data2 = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    var linea = data2["data"][0]["Arrive"][0]["line"];
                    Console.WriteLine($"Linea: {linea}");

                    //Acabar de devolver info por consola
                }
                else Console.WriteLine($"Error: {response.StatusCode}");

            }

        }
        static void EjercicioParking()
        {
            http.BaseAddress = new Uri("https://openapi.emtmadrid.es/v2/");

            http.DefaultRequestHeaders.Clear();

            string xClientId = "d84d5b34-3778-43cd-a491-17a5618bc49c";
            string passKey = "B6DC937C60C5757D53B3F9CB4CFF89EBA6E39770222C31215478A4547A95AA10B18CAF131121DB75836FE944DE87C5660D3A49C6121B93A9DF159985F85402A5";

            http.DefaultRequestHeaders.Add("X-ClientId", xClientId);
            http.DefaultRequestHeaders.Add("passKey", passKey);

            HttpResponseMessage response = http.GetAsync("mobilitylabs/user/login/").Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<dynamic>(content);
                string token = data.data[0].accessToken;

                // Headers

                http.DefaultRequestHeaders.Clear();
                http.DefaultRequestHeaders.Add("accessToken", token);

                HttpResponseMessage response2 = http.GetAsync("citymad/places/parkings/availability/").Result;
                if (response2.IsSuccessStatusCode)
                {
                    var content2 = response2.Content.ReadAsStringAsync().Result;
                    var data2 = JsonConvert.DeserializeObject<dynamic>(content2);

                    //var sitiosTotal = ;
                    
                    foreach (var item in data2["data"])
                    {
                        var parkingLibre = item.freeParking;
                        Console.WriteLine("=============================================================================");
                        Console.WriteLine($"Parking: {item.name}".PadRight(40) +
                            $"{(item.freeParking == null ? "Parking lleno" : "Sistios disponibles: " + item.freeParking)}");
                    }
                }
            }
        }
        public class EMTLogin
        {
            public string Code { get; set; }
            public string Description { get; set; }

            [JsonProperty("datetime")]
            public DateTime DateTimeData { get; set; }
            public List<EMTLoginData> Data { get; set; }
        }
    }
    public class EMTLoginData
        {
            public string AccessToken { get; set; }
            public int TokenSecExpiration { get; set; }
        }
    public class Body
        {
            public string cultureInfo { get; set; }
            public string Text_StopRequired_YN { get; set; }
            public string Text_EstimationsRequired_YN { get; set; }
            public string Text_IncidencesRequired_YN { get; set; }
            public string DateTime_Referenced_Incidencies_YYYYMMDD { get; set; }
        }
    public class ParkingResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }

        [JsonProperty("datetime")]
        public DateTime DateTimeData { get; set; }
        public List<ParkingData> Data { get; set; }
    }
    public class ParkingData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FreeParking { get; set; }
    }



}
