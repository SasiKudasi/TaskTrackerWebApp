using Task.Application.Shared;
namespace Task.Application.Commands.DeleteTask;

public record DeleteTaskCommand(Guid TaskId) : ICommand;
