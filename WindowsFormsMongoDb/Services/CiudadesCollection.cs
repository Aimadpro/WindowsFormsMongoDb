using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMongoDb.Models;

namespace WindowsFormsMongoDb.Services
{
    public static class CiudadesCollection
    {
        private static IMongoCollection<Ciudad> ciudadesCollection = MongoDB.db.GetCollection<Ciudad>("ciudad");

        public static List<Ciudad> GetAll()
        {
             List<Ciudad> ciudades = ciudadesCollection.Find(c => true).ToList();

             return ciudades;
        }
        public static void Insert(Ciudad ciudad)
        {
            ciudadesCollection.InsertOne(ciudad);
        }
        public static void Update(Ciudad ciudad)
        {
            ciudadesCollection.ReplaceOne(c => c.id == ciudad.id, ciudad);
        }
        public static void Delete(Ciudad ciudad)
        {
            ciudadesCollection.DeleteOne(C => C.id == ciudad.id);
        }

    }
}
