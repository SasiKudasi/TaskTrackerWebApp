using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Task.Application.Commands.CreateTask;
using Task.Application.Shared;

namespace Task.Application
{
    public static class AppDIExtensions
    {
        extension (IServiceCollection services)
        {
            public void AddAppServices()
            {
                services.AddScoped<ICommandHandler<CreateTaskCommand>, CreateTaskCommandHandler>();
            }
        }
    }
}
