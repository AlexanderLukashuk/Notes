using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notes.Application.Common.Behaviors;

namespace Notes.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
        }
    }
}