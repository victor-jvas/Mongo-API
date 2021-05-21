using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_API.Models
{
    public class InfectedDto
    {
        public DateTime birthDate { get; set; }
        public string Gender { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
