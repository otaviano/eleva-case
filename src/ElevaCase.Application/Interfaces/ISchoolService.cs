﻿using ElevaCase.Application.ViewModel;
using System.Collections.Generic;

namespace ElevaCase.Application.Interfaces
{
    public interface ISchoolService
    {
        IEnumerable<SchoolViewModel> GetSchools();

        void Create(SchoolViewModel model);
    }
}