using ElevaCase.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElevaCase.Application.Interfaces
{
    public interface ISchoolService
    {
        IEnumerable<SchoolViewModel> SearchSchools(string name);

        IEnumerable<SchoolViewModel> GetSchools();

        Task Create(SchoolViewModel model);
    }
}
