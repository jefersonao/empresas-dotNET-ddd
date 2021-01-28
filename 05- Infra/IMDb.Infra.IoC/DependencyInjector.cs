using Autofac;
using IMDb.Application.Interfaces;
using IMDb.Application.Services;
using IMDb.Domain.Interfaces.Repositories;
using IMDb.Domain.Interfaces.Services;
using IMDb.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IMDb.Infra.IoC
{
    public class DependencyInjector
    {

        public static void Load(ContainerBuilder builder)
        {
            //App
            builder.RegisterType<ApplicationServiceMovie>().As<IApplicationServiceMovie>();
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();

            //Service
            builder.RegisterType<ApplicationServiceMovie>().As<IApplicationServiceMovie>();
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();

            //Repository
            builder.RegisterType<RepositoryMovie>().As<IRepositoryMovie>();
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();

        }



        public static void Register(IServiceCollection svcCollection)
        {
            //Application
            svcCollection.AddScoped(typeof(iAPPP<>), typeof(BaseApp<>));
           // svcCollection.AddScoped<IMovieApp, MovieApp>();
            //svcCollection.AddScoped<IUserService, UserService>();

            //Domain
            svcCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            //svcCollection.AddScoped<IMovieService, MovieService>();
            //svcCollection.AddScoped<IUserService, UserService>();


            //Repository
            svcCollection.AddScoped(typeof(BaseRepository<>), typeof(BaseRepository<>));
            //svcCollection.AddScoped<IMovieRepository, MovieRepository>();
        }

    }
}
