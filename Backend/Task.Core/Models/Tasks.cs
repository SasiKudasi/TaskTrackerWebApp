namespace Task.Core.Models;
public class Tasks
{
    private Tasks(Guid id, string title, string description, DateTime date)
    {
        Id = id;
        Title = title;
        Description = description;
        Date = date;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime Date { get; private set; } = DateTime.Now;


    public static Tasks Create(Guid id, string title, string description, DateTime date)
    {
        var task = new Tasks(id, title, description, date);
        return task;
    }
}

