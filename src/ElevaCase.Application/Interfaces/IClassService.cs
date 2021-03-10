using ElevaCase.Application.ViewModel;
using System.Collections.Generic;

namespace ElevaCase.Application.Interfaces
{
    public interface IClassService
    {
        IEnumerable<ClassViewModel> GetClasses(int schoolId);

        void Create(ClassViewModel model);
    }
}
