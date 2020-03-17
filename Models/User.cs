using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Models
{
    public class User
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public ICollection<Transaction> transactions { get; set; }
    }
}
