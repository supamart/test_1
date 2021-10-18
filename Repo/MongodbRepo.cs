using System.Collections.Generic;
using MongoDB.Driver;
using testapisecond.Entity;

namespace testapisecond.Repo
{
    public class MongodbRepo : IRepo
    {
        private readonly IMongoCollection<EntityModel> _mongocontext;

        private const string dbName = "catalog";
        private const string collectionName = "entities";

        public MongodbRepo(IMongoClient mongocontext)
        {
            IMongoDatabase database = mongocontext.GetDatabase(dbName);
            _mongocontext = database.GetCollection<EntityModel>(collectionName);
        }
        public void Create(EntityModel model)
        {
            _mongocontext.InsertOne(model);
        }

        public void Delete(EntityModel model)
        {
            
        }

        public IEnumerable<EntityModel> Get()
        {
            throw new System.NotImplementedException();
        }

        public EntityModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool savechanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(EntityModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}