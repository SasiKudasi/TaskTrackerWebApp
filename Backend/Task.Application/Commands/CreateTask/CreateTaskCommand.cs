using Task.Application.Shared;

namespace Task.Application.Commands.CreateTask;

public record CreateTaskCommand(Guid TaskID, string Title, string Description) : ICommand;
