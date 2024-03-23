using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;

namespace Notes.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NotesDbContext>(options =>
            {
                options.UseSqlite(connectionString ?? throw new Exception("Connection string not found"));
            });
            services.AddScoped<INotesDbContext>(provider => provider.GetService<NotesDbContext>());

            return services;
        }
    }
}