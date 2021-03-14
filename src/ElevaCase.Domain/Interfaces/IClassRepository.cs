using ElevaCase.Domain.Entities;
using System.Linq;

namespace ElevaCase.Domain.Interfaces
{
    public interface IClassRepository
    {
        IQueryable<@Class> GetAll(int schoolId);

        IQueryable<@Class> Search(int schoolId, string name);

        void Create(@Class @class);
    }
}
