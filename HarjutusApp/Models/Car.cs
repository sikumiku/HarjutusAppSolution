using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarjutusApp.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string ManufactureYear { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string LicensePlate { get; set; }
        public int PersonId { get; set; }
    }
}
