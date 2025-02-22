using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMongoDb.Models
{
    public class Ciudad
    {
        [BsonId]
        public ObjectId id {  get; set; }

        [BsonElement("nombre")]
        public string nombre { get; set; }
    }
}
