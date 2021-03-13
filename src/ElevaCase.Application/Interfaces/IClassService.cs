using ElevaCase.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElevaCase.Application.Interfaces
{
    public interface IClassService
    {
        IEnumerable<ClassViewModel> SearchClasses(int schoolId, string name);

        IEnumerable<ClassViewModel> GetClasses(int schoolId);

        Task Create(ClassViewModel model);
    }
}
