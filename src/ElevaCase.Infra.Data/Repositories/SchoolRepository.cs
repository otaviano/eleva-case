using ElevaCase.Domain.Entities;
using ElevaCase.Domain.Interfaces;
using ElevaCase.Infra.Data.Context;
using System.Linq;

namespace ElevaCase.Infra.Data.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ElevaCaseDbContext dbContext;

        public SchoolRepository(ElevaCaseDbContext dbContext) => 
            this.dbContext = dbContext;

        public IQueryable<School> GetAll() => 
            dbContext.Schools;

        public void Add(School school)
        {
            dbContext.Schools.Add(school);
            dbContext.SaveChanges();
        }
    }
}
