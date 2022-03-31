using System;
using System.Collections.Generic;

#nullable disable

namespace Demo3.Sopra.ConsoleApp1.Models
{
    public partial class Products_by_Category
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public short? UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
