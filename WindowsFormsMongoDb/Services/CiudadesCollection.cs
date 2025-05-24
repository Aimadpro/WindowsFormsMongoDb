using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsMongoDb.Models;

namespace WindowsFormsMongoDb.Services
{
    /// <summary>
    /// Clase estática para gestionar la colección de ciudades en MongoDB.
    /// </summary>
    public static class CiudadesCollection
    {
        private static IMongoCollection<Ciudad> ciudadesCollection = MongoDB.db.GetCollection<Ciudad>("ciudad");

        /// <summary>
        /// Obtiene todas las ciudades de la colección.
        /// </summary>
        /// <returns>Lista de ciudades.</returns>
        public static List<Ciudad> GetAll()
        {
            List<Ciudad> ciudades = ciudadesCollection.Find(c => true).ToList();
            return ciudades;
        }

        /// <summary>
        /// Inserta una nueva ciudad en la colección.
        /// </summary>
        /// <param name="ciudad">Ciudad a insertar.</param>
        public static void Insert(Ciudad ciudad)
        {
            ciudadesCollection.InsertOne(ciudad);
        }

        /// <summary>
        /// Actualiza una ciudad existente en la colección.
        /// </summary>
        /// <param name="ciudad">Ciudad a actualizar.</param>
        public static void Update(Ciudad ciudad)
        {
            ciudadesCollection.ReplaceOne(c => c.id == ciudad.id, ciudad);
        }

        /// <summary>
        /// Elimina una ciudad de la colección.
        /// </summary>
        /// <param name="ciudad">Ciudad a eliminar.</param>
        public static void Delete(Ciudad ciudad)
        {
            ciudadesCollection.DeleteOne(C => C.id == ciudad.id);
        }
    }
}
