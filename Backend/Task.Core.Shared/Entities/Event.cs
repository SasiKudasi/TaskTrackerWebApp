using System.ComponentModel.DataAnnotations;

namespace Task.Core.Shared.Entities;

public abstract class Event
{
    protected Event(DateTime creationDate)
    {
        Id = Guid.NewGuid(); ;
        CreationDate = creationDate;
    }
    protected Event() {/*for json serializer*/}

    [Required]
    public Guid Id { get; init; }

    [Required]
    public DateTime CreationDate { get; init; }
}
