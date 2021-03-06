using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ElevaCase.Application.Interfaces;
using ElevaCase.Application.ViewModel;
using ElevaCase.Domain.Commands;
using ElevaCase.Domain.Core.Bus;
using ElevaCase.Domain.Interfaces;

namespace ElevaCase.Domain.Service
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository classRepository;
        private readonly IMediatorHandler bus;
        private readonly IMapper autoMapper;

        public ClassService(IMapper autoMapper, IClassRepository classRepository, IMediatorHandler bus)
        {
            this.bus = bus;
            this.autoMapper = autoMapper;
            this.classRepository = classRepository;
        }

        public async Task Create(ClassViewModel model)
        {
            var command = autoMapper.Map<CreateClassCommand>(model);

            await bus.SendCommand(command);
        }

        public IEnumerable<ClassViewModel> GetClasses(int schoolId)
        {
            var classes = classRepository.GetAll(schoolId);

            return classes.ProjectTo<ClassViewModel>(autoMapper.ConfigurationProvider) ;
        }

        public IEnumerable<ClassViewModel> SearchClasses(int schoolId, string name)
        {
            var classes = classRepository.Search(schoolId, name);

            return classes.ProjectTo<ClassViewModel>(autoMapper.ConfigurationProvider);
        }
    }
}
