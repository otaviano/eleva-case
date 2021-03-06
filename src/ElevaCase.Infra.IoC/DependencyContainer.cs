using Microsoft.Extensions.DependencyInjection;
using ElevaCase.Application.Interfaces;
using ElevaCase.Domain.Service;
using ElevaCase.Domain.Interfaces;
using ElevaCase.Infra.Data.Repositories;
using ElevaCase.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ElevaCase.Domain.Core.Bus;
using ElevaCase.Bus;
using MediatR;
using ElevaCase.Domain.CommandHandlers;
using ElevaCase.Domain.Commands;

namespace ElevaCase.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IConfiguration configuration, IServiceCollection services)
        {
            RegisterDomain(services);
            RegisterApplication(services);
            RegisterDomainInMemmoryMediatR(services);
            RegisterInfraData(configuration, services);
        }

        private static void RegisterApplication(IServiceCollection services)
        {
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ISchoolService, SchoolService>();
        }

        private static void RegisterInfraData(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<ElevaCaseDbContext>(p =>
            {
                p.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
        }

        private static void RegisterDomain(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateClassCommand, bool>, ClassCommandHandler>();
            services.AddScoped<IRequestHandler<CreateSchoolCommand, bool>, SchoolCommandHandler>();
        }

        private static void RegisterDomainInMemmoryMediatR(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();
        }
    }
}
