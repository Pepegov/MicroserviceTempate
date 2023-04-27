﻿using Microsoft.EntityFrameworkCore;

namespace MicroserviceTemplate.DAL.Database
{
    public class DatabaseInitializer
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ApplicationDbContext _context;

        public DatabaseInitializer(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }
        
        public async Task Seed()
        {
            await _context!.Database.EnsureCreatedAsync();
            var pending = await _context.Database.GetPendingMigrationsAsync(); //Асинхронно получает все миграции, определенные в сборке, но не примененные к целевой базе данных.
            if (pending.Any())
            {
                await _context!.Database.MigrateAsync();
            }
        }
    }
}
