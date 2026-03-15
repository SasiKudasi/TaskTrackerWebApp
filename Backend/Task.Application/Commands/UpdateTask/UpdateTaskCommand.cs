using Task.Application.Shared;

namespace Task.Application.Commands.UpdateTask;

public record UpdateTaskCommand(Guid TaskId, string Title, string Description) : ICommand;
