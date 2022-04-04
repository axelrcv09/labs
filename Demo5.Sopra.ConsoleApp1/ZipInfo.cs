using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo5.Sopra.ConsoleApp1
{
    public class ZipInfo
    {
        [JsonProperty("post code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }

        [JsonProperty("country abbreviation")]
        public string CountryCode { get; set; }
        public List<PlaceZipInfo> Places { get; set; }
    }

    public class PlaceZipInfo
    {
        [JsonProperty("place name")]
        public string Name { get; set; }

        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string State { get; set; }

        [JsonProperty("state abbreviation")]
        public string StateCode { get; set; }
    }

}
