namespace DevFreela.Application.ViewModels;

public class ProjectDetailsViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ClientFullName { get; set; }
    public string FreelancerFullName { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }

    public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finishedAt, string clientFullName, string freelancerFullName)
    {
        Id = id;
        Title = title;
        Description = description;
        TotalCost = totalCost;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
        ClientFullName = clientFullName;
        FreelancerFullName = freelancerFullName;
    }
}