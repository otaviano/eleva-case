using ElevaCase.Domain.Entities;
using System.Linq;

namespace ElevaCase.Domain.Interfaces
{
    public interface ISchoolRepository
    {
        IQueryable<School> GetAll();

        void Add(School school);
    }
}
