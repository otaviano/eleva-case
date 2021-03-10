using AutoMapper;
using ElevaCase.Application.ViewModel;
using ElevaCase.Domain.Commands;

namespace ElevaCase.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ClassViewModel, CreateClassCommand>()
                .ConstructUsing(p => new CreateClassCommand(p.SchoolId, p.Name, p.Description));

            CreateMap<SchoolViewModel, CreateSchoolCommand>()
                .ConstructUsing(p => new CreateSchoolCommand(p.Name, p.Description));
        }
    }
}
