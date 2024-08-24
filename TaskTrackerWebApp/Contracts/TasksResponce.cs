using System;
namespace TaskTrackerWebApp.Contracts
{
	public record TasksResponce (Guid Id,
		string Title,
		string Description,
		DateTime Date);
}

