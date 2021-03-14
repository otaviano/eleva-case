using ElevaCase.Domain.Entities;
using ElevaCase.Domain.Interfaces;
using ElevaCase.Infra.Data.Context;
using System.Linq;

namespace ElevaCase.Infra.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly ElevaCaseDbContext dbContext;

        public ClassRepository(ElevaCaseDbContext dbContext) => 
            this.dbContext = dbContext;


        public IQueryable<@Class> Search(int schoolId, string name) =>
            dbContext.Classes.Where(p => p.School.Id == schoolId && p.Name.Contains(name ?? string.Empty));

        public IQueryable<@Class> GetAll(int schoolId) => 
            dbContext.Classes.Where(p => p.School.Id == schoolId);

        public void Create(@Class @class)
        {
            dbContext.Classes.Add(@class);
            dbContext.SaveChanges();
        }
    }
}
