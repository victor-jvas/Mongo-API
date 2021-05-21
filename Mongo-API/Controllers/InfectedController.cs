using Microsoft.AspNetCore.Mvc;
using Mongo_API.Data.Collections;
using Mongo_API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedCollection;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public ActionResult<Infected> CreateInfected([FromBody] InfectedDto dto)
        {
            var infected = new Infected(dto.birthDate, dto.Gender, dto.Latitude, dto.Longitude);

            _infectedCollection.InsertOne(infected);

            return Created(nameof(CreateInfected), infected);
        }

        [HttpGet]
        public ActionResult GetInfecteds(){

            var infecteds = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();

            return Ok(infecteds);
        }

        [HttpGet("{gender}")]
        public ActionResult GetInfectedByGender([FromRoute] string gender)
        {
            var infected = _infectedCollection.Find(x=> x.Gender == gender);
            return Ok(infected);
        }

    }
}
