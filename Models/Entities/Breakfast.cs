namespace SimpleBreakfast.Models.Entities;

public partial class Breakfast
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public DateTime? LastModifiedDateTime { get; set; }

    public string? Savory { get; set; }

    public string? Sweet { get; set; }

    public Breakfast(Guid id, string? name, string? description, DateTime? startDateTime, DateTime? endDateTime, DateTime? lastModifiedDateTime, string? savory, string? sweet)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }
}
