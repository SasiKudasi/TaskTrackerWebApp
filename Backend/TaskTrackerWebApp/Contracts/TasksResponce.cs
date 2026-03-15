using System;
namespace TaskTrackerWebApp.Contracts
{
	public record TasksResponce (
		Guid TaskId,
		string Title,
		string Description,
		DateTime Date);
}

