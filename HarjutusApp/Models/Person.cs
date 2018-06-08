using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarjutusApp.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string  Lastname { get; set; }
        public string Birthday { get; set; }
        public string IdCode { get; set; }
        public int Age { get; set; }
        public List<Car> Cars { get; set; }

    }
}
