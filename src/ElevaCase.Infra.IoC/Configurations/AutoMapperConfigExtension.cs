using AutoMapper;
using ElevaCase.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ElevaCase.Infra.IoC.Configurations
{
    public static class AutoMapperConfigExtension
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
        }
    }
}
