using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_API.Data.Collections
{
    public class Infected
    {
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public GeoJson2DGeographicCoordinates Location { get; set; }

        public Infected(DateTime birthDate, string gender, double latitude, double longitude)
        {
            BirthDate = birthDate;
            Gender = gender;
            Location = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
    }
}
