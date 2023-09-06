namespace DevFreela.Core.Entities;

public class Skill : BaseEntity
{
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Skill(string description, DateTime createdAt)
    {
        Description = description;
        CreatedAt = createdAt;
    }
}