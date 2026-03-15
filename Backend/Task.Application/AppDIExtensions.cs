using Microsoft.Extensions.DependencyInjection;
using Task.Application.Commands.CreateTask;
using Task.Application.Commands.DeleteTask;
using Task.Application.Commands.UpdateTask;
using Task.Application.EventHandlers;
using Task.Application.Queries.GetTask;
using Task.Application.Queries.GetTasks;
using Task.Application.Shared;
using Task.Core.Abstraction;
using Task.Core.DomainEvents;
using Task.Core.Models;
using Task.EventBus;
using Task.EventBus.Abstractions;

namespace Task.Application;

public static class AppDIExtensions
{
    extension (IServiceCollection services)
    {
        public void AddAppServices()
        {
            services.AddScoped<ITaskUnitOfWork, TaskUnitOfWork>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();

            services.AddScoped<IEventHandler<TaskCreatedEvent>, TaskCreatedEventHandler>();

            services.AddScoped<ICommandHandler<CreateTaskCommand>, CreateTaskCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteTaskCommand>, DeleteTaskCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateTaskCommand>, UpdateTaskCommandHandler>();


            services.AddScoped<IQueryHandler<GetTasksQuery, List<Tasks>>, GetTasksQueryHandler>();
            services.AddScoped<IQueryHandler<GetTaskQuery, Tasks>, GetTaskQueryHandler>();
        }
    }
}
