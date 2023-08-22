using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using N5Company.Core.Application.Behaviors;
using System.Reflection;

namespace N5Company.Core.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
