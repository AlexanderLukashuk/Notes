using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notes.Application.Interfaces;

namespace Notes.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IHostApplicationBuilder builder)
        {
            builder.Services.AddDbContext<NotesDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("AuthContex_Test") ?? throw new Exception("Test connection string not found"));
            });

            builder.Services.AddScoped<INotesDbContext>(provider => provider.GetService<NotesDbContext>());
        }
    }
}