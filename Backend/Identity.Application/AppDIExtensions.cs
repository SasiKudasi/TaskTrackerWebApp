using Identity.Application.Commands.CreateUser;
using Identity.Application.Commands.LoginUser;
using Identity.Application.Queries.GetUsers;
using Identity.Domain;
using Identity.Infrastructure.JwtUtils;
using Microsoft.Extensions.DependencyInjection;
using Task.Application;
using Task.Application.Shared;
using Task.EventBus;
using Task.EventBus.Abstractions;

namespace Identity.Application;

public static class AppDIExtensions
{
    extension (IServiceCollection services)
    {
        public void AddAppServices()
        {
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();
            services.AddScoped<JwtProvider>();


            services.AddScoped<IQueryHandler<GetUsersQuery, List<User>>, GetUsersQueryHandler>();

            services.AddScoped<ICommandHandler<CreateUserCommand>, CreateUserCommandHandler>();
            services.AddScoped<ICommandHandler<LoginUserCommand>, LoginUserCommandHandler>();

        }
    }
}
