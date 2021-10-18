using System;
using System.Collections.Generic;
using testapisecond.Entity;
using System.Linq;

namespace testapisecond.Repo
{
    public class MockRepo : IRepo
    {

      
         static  List<EntityModel> entityModels = new List<EntityModel>()
        {
            new EntityModel{Id = 1, Name = "Leo", Email="abc@1",DateTime=DateTimeOffset.UtcNow},
            new EntityModel{Id = 2, Name = "Neo", Email="def@1",DateTime=DateTimeOffset.UtcNow},
            new EntityModel{Id = 3, Name = "Zeo", Email="ghi@1",DateTime=DateTimeOffset.UtcNow}
        };

        public void Create(EntityModel model)
        {
            if(model == null )
            {
                throw new ArgumentNullException(nameof(model));
            }
            entityModels.Add(model);
        }

        public void Delete(EntityModel model)
        {            
            if(model == null )
            {
                throw new ArgumentNullException(nameof(model));
            }

            entityModels.Remove(model);
        }

        public IEnumerable<EntityModel> Get()
        {
           return entityModels;
        }

        public EntityModel GetById(int Id)
        {
           // return entityModels[Id];
            return entityModels.Where(i => i.Id == Id).SingleOrDefault();
        }

        public bool savechanges()
        {
            throw new NotImplementedException();
        }

        public void Update(EntityModel model)
        {
            var index = entityModels.FindIndex(i => i.Id == model.Id);
            if (index<0){ throw new ArgumentOutOfRangeException(" not found"); }
             entityModels[index]=model;
            

        }
    }
}