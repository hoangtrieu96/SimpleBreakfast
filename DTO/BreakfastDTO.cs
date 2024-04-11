namespace SimpleBreakfast.DTO;

public class BreakfastDTO
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public DateTime? LastModifiedDateTime { get; set; }

    public string? Savory { get; set; }

    public string? Sweet { get; set; }
}
