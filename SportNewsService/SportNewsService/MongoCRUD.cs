using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

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
      
        
        //  public void InsertNewField<T>(string table,string filterField,int filterCountent,string newfieldName, string Record)
       //  {
       //      var colection = db.GetCollection<T>(table);
       //     
       //      FilterDefinition<BsonDocument> filterdef = new BsonDocument (filterField,filterCountent);
       //      var filter = Builders<T>.Filter.Eq(filterField, filterCountent);
       //      UpdateDefinition<T> update = new BsonDocument("$set", new BsonDocument(newfieldName, Record));
       //    //  var updatee = Builders<T>.Update.Combine(newfieldName,Record);
       //
       // //   var up = update.Set(obj, objProperty).Set(newfieldName, Record);
       //      colection.UpdateOne(filter,update);
       //      // colection.UpdateOne(}{link:filter},{$set:{fieldName:Record}});
       //
       //
       //  }

      

    }

    
}
