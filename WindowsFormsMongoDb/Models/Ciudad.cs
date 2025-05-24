using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMongoDb.Models
{
    /// <summary>
    /// Modelo de datos para una ciudad.
    /// </summary>
    public class Ciudad
    {
        /// <summary>
        /// Identificador único de la ciudad (MongoDB ObjectId).
        /// </summary>
        [BsonId]
        public ObjectId id { get; set; }

        /// <summary>
        /// Nombre de la ciudad.
        /// </summary>
        [BsonElement("nombre")]
        public string nombre { get; set; }
    }
}
