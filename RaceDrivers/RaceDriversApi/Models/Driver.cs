using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceDriversApi.Models
{
    public class Driver
    {
        //Specifies that it is and Id
        [BsonId]
        //Specifes the type primaryKey type coming from  our Id
         
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        //wE USE THESE TO MAP these
        //name in database Name while in C\ DriversName
        [BsonElement("Name")]
        public string DriversName { get; set; }
        public int Number { get; set; }
        //We can also set the Initalization to NuLL if u want
        public string Team { get; set; } = null;
    }
}
