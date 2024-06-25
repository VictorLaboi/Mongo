using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMongo2024
{
    internal class Alumno
    {
        
        private readonly IMongoCollection<Alumno> _collection;

        public Alumno()
        { 
            MongoClient client = new MongoClient("mongodb://localhost:27017/");
            IMongoDatabase database = client.GetDatabase("admin");
            _collection = database.GetCollection<Alumno>("alumnos");

        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("nombre")]
        public string Nombre { get; set; }


        [BsonElement("apellido")]
        public string Apellido { get; set; }


        [BsonElement("matricula")]
        public string Matricula { get; set; }


        [BsonElement("grupo")]
        public string Grupo { get; set; }

        public void Agregar(Alumno alumno)
        {
            _collection.InsertOne(alumno);
        }

        public Alumno ConsultarPorMatricula(string matricula)
        {
            return _collection
                .Find(a => a.Matricula == matricula)
                .FirstOrDefault<Alumno>();
        }
        public List<Alumno> ConsultarTodos(string matricula) { 
            return _collection.Find(a=> a.Matricula == matricula).ToList();
        }
        public Alumno ConsultarPorNombre(string nombre)
        {
            return _collection
                .Find(a => a.Nombre == nombre)
                .FirstOrDefault<Alumno>();
        }

        public void Actualizar(string matricula, Alumno alumno)
        {
            Alumno alumnoDB = ConsultarPorMatricula(matricula);
            if (alumnoDB != null)
            {
                _collection.ReplaceOne(a => a.Id == alumnoDB.Id, alumno);
            }
        }

        public void Eliminar(string matricula)
        {
            Alumno alumnoDB = ConsultarPorMatricula(matricula);
            if (alumnoDB != null)
            {
                _collection.DeleteOne(a => a.Id == alumnoDB.Id);
            }
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido}  matricula: {Matricula} grupo: {Grupo} ";
        }
    }
}
