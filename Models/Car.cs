using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class Car
    {
        public Guid id { get; set; }
        public string brand { get; set; }
        public string type { get; set; }
        public string production_year { get; set; }
        public string seat { get; set; }
        public string transmision { get; set; }
        public string ac { get; set; }
        public string fuel { get; set; }
        public string status { get; set; }
        public string priceperday { get; set; }
        public string front_image { get; set; }
        public string back_image { get; set; }
        public string top_image { get; set; }
        public string left_image { get; set; }
        public string right_image { get; set; }
        public string baggage { get; set; }
        public string description { get; set; }
        public string owner { get; set; }
        public DateTime created_at { get; set; }

    }
}
