using Microsoft.EntityFrameworkCore;
using Task.Core.Abstraction;
using Task.DataAccess;
using Task.DataAccess.Repository;
using Task.Application;
using Task.EventBus.Abstractions;
using Task.EventBus;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<TaskDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(TaskDbContext)));
    });

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddAppServices();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

