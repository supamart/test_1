using System.Collections.Generic;
using testapisecond.Entity;

namespace testapisecond.Repo
{
    public interface IRepo
    {
         IEnumerable<EntityModel> Get();
         EntityModel GetById(int id);
         
         void Create(EntityModel model);

         void Update(EntityModel model);

         void Delete(EntityModel model);

         bool savechanges();



    }
}