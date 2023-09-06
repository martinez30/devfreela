using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaContext
{
    public List<Project> Projects { get; set; }
    public List<User> Users { get; set; }
    public List<Skill> Skills { get; set; }

    public DevFreelaContext()
    {
        Projects = new List<Project>()
        {
            new Project("Meu projeto AspNet Core", "Minha descrição de projeto", 1, 2, 10000),
            new Project("Meu projeto Angular", "Minha descrição de projeto", 1, 2, 20000),
            new Project("Meu projeto React", "Minha descrição de projeto", 1, 2, 30000),
        };

        Users = new List<User>()
        {
            new User("Admin", "admin@admin.com", new DateTime(2000, 01, 01)),
            new User("Steve Jobs", "steve.jobs@admin.com", new DateTime(2000, 01, 01)),
            new User("Ben Afflec", "ben.afflec@admin.com", new DateTime(2000, 01, 01))
        };

        Skills = new List<Skill>()
        {
            new Skill("C#"),
            new Skill("SQL"),
            new Skill("AspNetCore"),
        };
    }
}