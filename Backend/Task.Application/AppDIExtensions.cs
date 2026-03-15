using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Task.Application.Commands.CreateTask;
using Task.Application.Commands.DeleteTask;
using Task.Application.Commands.UpdateTask;
using Task.Application.Queries.GetTask;
using Task.Application.Queries.GetTasks;
using Task.Application.Shared;
using Task.Core.Models;

namespace Task.Application
{
    public static class AppDIExtensions
    {
        extension (IServiceCollection services)
        {
            public void AddAppServices()
            {
                services.AddScoped<ICommandHandler<CreateTaskCommand>, CreateTaskCommandHandler>();
                services.AddScoped<ICommandHandler<DeleteTaskCommand>, DeleteTaskCommandHandler>();
                services.AddScoped<ICommandHandler<UpdateTaskCommand>, UpdateTaskCommandHandler>();


                services.AddScoped<IQueryHandler<GetTasksQuery, List<Tasks>>, GetTasksQueryHandler>();
                services.AddScoped<IQueryHandler<GetTaskQuery, Tasks>, GetTaskQueryHandler>();
            }
        }
    }
}
