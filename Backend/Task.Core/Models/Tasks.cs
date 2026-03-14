using System;
namespace Task.Core.Models
{
	public class Tasks
	{
		private Tasks(Guid id, string title, string description, DateTime date)
		{
			Id = id;
			Title = title;
			Description = description;
			Date = date;
		}

		public Guid Id { get; }
		public string Title { get; } = string.Empty;
		public string Description { get; } = string.Empty;
		public DateTime Date { get; } = DateTime.Now;

		public static Tasks Create (Guid id, string title, string description, DateTime date)
		{
			var task = new Tasks(id, title, description, date);
			return task;
		}
	}
}

