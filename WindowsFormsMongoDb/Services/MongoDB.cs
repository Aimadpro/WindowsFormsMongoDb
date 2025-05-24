using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMongoDb.Services
{
    /// <summary>
    /// Clase estática para gestionar la conexión a la base de datos MongoDB.
    /// </summary>
    public static class MongoDB
    {
        /// <summary>
        /// Cliente de MongoDB conectado a localhost.
        /// </summary>
        public static MongoClient client = new MongoClient("mongodb://localhost:27017");

        /// <summary>
        /// Base de datos "turismo".
        /// </summary>
        public static IMongoDatabase db = client.GetDatabase("turismo");
    }
}
