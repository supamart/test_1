using Microsoft.EntityFrameworkCore;
using testapisecond.Entity;

namespace testapisecond.Repo
{
    public class RepoContext : DbContext
    {
        public RepoContext(DbContextOptions<RepoContext> opt) :base(opt)
        {
                    
        }

        public DbSet<EntityModel> Entities { get; set; }
    }
}