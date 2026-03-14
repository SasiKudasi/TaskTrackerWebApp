using System;
namespace TaskTrackerWebApp.Contracts
{
	public record TaskRequest (string Title,
        string Description,
        DateTime Date);
	
}

