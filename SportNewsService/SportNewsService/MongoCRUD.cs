using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportNewsService
{
    class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {

            var client = new MongoClient();
            db = client.GetDatabase(database);
        }
        public void InsertRecord<T>(string table, T Record)
        {
            var colection = db.GetCollection<T>(table);
            colection.InsertOne(Record);
        }
    }

    
}
