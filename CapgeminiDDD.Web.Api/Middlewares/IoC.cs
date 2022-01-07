using CapgeminiDDD.Common.Model;
using CapgeminiDDD.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CapgeminiDDD.Web.Api.Middlewares
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Student>), typeof(StudentRepository));

            return services;
        }
    }
}
