namespace TODO_List.Models;

public class Task : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Fromdate { get; set; }

    public DateTime? Todate { get; set; }

    public string Urgency { get; set; } = null!;

    public bool Iscompleted { get; set; }
}
