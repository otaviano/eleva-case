using ElevaCase.Domain.Entities;
using System.Linq;

namespace ElevaCase.Domain.Interfaces
{
    public interface ISchoolRepository
    {
        IQueryable<School> SearchSchools(string name);

        IQueryable<School> GetAll();

        void Create(School school);
    }
}
