using AutoMapper;
using ElevaCase.Application.ViewModel;
using ElevaCase.Domain.Commands;
using ElevaCase.Domain.Entities;

namespace ElevaCase.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<@Class, ClassViewModel>();
            CreateMap<School, SchoolViewModel>();
        }
    }
}
