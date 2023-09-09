namespace DevFreela.Application.ViewModels;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }

    public ProjectViewModel(string title, DateTime createdAt)
    {
        Title = title;
        CreatedAt = createdAt;
    }
}