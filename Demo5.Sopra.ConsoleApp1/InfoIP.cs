using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo5.Sopra.ConsoleApp1
{
    public class InfoIP
    {
        public string status { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string timezone { get; set; }
        public string isp { get; set; }
        public string org { get; set; }
        public string query { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }

        [JsonProperty("as")]
        public string registro { get; set; }

        public void Demo()
        {
            Console.WriteLine($"{query} {country} {city}");
        }
    }

    public class InfoIP2
    {
        public string country { get; set; }
        public string city { get; set; }
        public string query { get; set; }

        //public string as { get; set; }
    }

}
