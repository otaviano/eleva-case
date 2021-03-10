﻿using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ElevaCase.Application.Interfaces;
using ElevaCase.Application.ViewModel;
using ElevaCase.Domain.Commands;
using ElevaCase.Domain.Core.Bus;
using ElevaCase.Domain.Interfaces;

namespace ElevaCase.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository schoolRepository;
        private readonly IMediatorHandler bus;
        private readonly IMapper autoMapper;

        public SchoolService(IMapper autoMapper, ISchoolRepository schoolRepository, IMediatorHandler bus)
        {
            this.bus = bus;
            this.autoMapper = autoMapper;
            this.schoolRepository = schoolRepository;
        }

        public void Create(SchoolViewModel model)
        {
            var command = autoMapper.Map<CreateSchoolCommand>(model);

            bus.SendCommand(command);
        }

        public IEnumerable<SchoolViewModel> GetSchools()
        {
            var schools = schoolRepository.GetAll();

            return schools.ProjectTo<SchoolViewModel>(autoMapper.ConfigurationProvider) ;
        }
    }
}