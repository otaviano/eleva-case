using ElevaCase.Domain.Entities;
using System.Linq;

namespace ElevaCase.Domain.Interfaces
{
    public interface IClassRepository
    {
        IQueryable<@Class> GetAll(int schoolId);

        void Add(@Class @class);
    }
}
