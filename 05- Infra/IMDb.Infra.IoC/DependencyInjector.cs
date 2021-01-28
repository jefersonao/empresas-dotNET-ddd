using Autofac;
using IMDb.Application.Interfaces;
using IMDb.Application.Services;
using IMDb.Domain.Interfaces.Repositories;
using IMDb.Domain.Interfaces.Services;
using IMDb.Domain.Services;
using IMDb.Infra.Data.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace IMDb.Infra.IoC
{
    public static class ServicesDependency
    {
        public static void AddServiceDependency(IServiceCollection services)
        {
            //App
            services.AddScoped<IApplicationServiceMovie, ApplicationServiceMovie>();
            services.AddScoped<IApplicationServiceUser, ApplicationServiceUser>();

            //Service
            services.AddScoped<IApplicationServiceMovie, ApplicationServiceMovie>();
            services.AddScoped<IApplicationServiceUser, ApplicationServiceUser>();

            //Repository
            services.AddScoped<IRepositoryMovie, RepositoryMovie>();
            services.AddScoped<IRepositoryUser, RepositoryUser>();
            }
        }
    }
