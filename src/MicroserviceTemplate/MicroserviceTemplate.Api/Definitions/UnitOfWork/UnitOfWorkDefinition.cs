﻿using MicroserviceTemplate.DAL.Database;
using Pepegov.MicroserviceFramerwork.AspNetCore.Definition;
using Pepegov.UnitOfWork.EntityFramework;

namespace MicroserviceTemplate.Api.Definitions.UnitOfWork
{
    public class UnitOfWorkDefinition : Definition
    {
        public override void ConfigureServicesAsync(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddUnitOfWorkEF<ApplicationDbContext>();
        }
    }
}
