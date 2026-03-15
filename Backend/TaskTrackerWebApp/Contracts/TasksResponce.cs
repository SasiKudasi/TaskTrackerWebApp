using System;
namespace TaskTrackerWebApp.Contracts
{
	public record TasksResponce (
		string Title,
		string Description,
		DateTime Date);
}

