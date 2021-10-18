using System;
using System.Collections.Generic;
using System.Linq;
using testapisecond.Entity;

namespace testapisecond.Repo
{
    public class SqlRepo : IRepo
    {
        private readonly RepoContext _context;

        public SqlRepo(RepoContext context)
        {
            _context = context;
        }
        public void Create(EntityModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            
                _context.Entities.Add(model);
                _context.SaveChanges();
        }

        public void Delete(EntityModel model)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EntityModel> Get()
        {
            return _context.Entities.ToList(); // repository.DbSet
        }

        public EntityModel GetById(int id)
        {
            return _context.Entities.FirstOrDefault(p => p.Id == id);

            
        }

        public bool savechanges()
        {
           return (_context.SaveChanges()>=0);
        }


        public void Update(EntityModel model)
        {
            //
        }
    }
}