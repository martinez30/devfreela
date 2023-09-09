using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly DevFreelaContext _context;

    public ProjectService(DevFreelaContext context)
    {
        _context = context;
    }

    public List<ProjectViewModel> GetAll(string query)
    {
        var projects = _context.Projects;
        var projectsViewModel = projects
            .Select(x => new ProjectViewModel(x.Title, x.CreatedAt))
            .ToList();
        return projectsViewModel;
    }

    public ProjectDetailsViewModel GetById(int id)
    {
        var project = _context.Projects.SingleOrDefault(x => x.Id == id);
        return new ProjectDetailsViewModel(
            project.Id,
            project.Title,
            project.Description,
            project.TotalCost,
            project.StartedAt,
            project.FinishedAt
        );
    }

    public int Create(NewProjectInputModel inputModel)
    {
        var project = new Project(inputModel.Title, inputModel.Description, inputModel.ClientId, inputModel.FreelancerId, inputModel.TotalCost);
        _context.Projects.Add(project);
        return project.Id;
    }

    public void Update(UpdateProjectInputModel inputModel)
    {
        var project = _context.Projects.SingleOrDefault(x => x.Id == inputModel.Id);
        project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
    }

    public void Delete(int id)
    {
        var project = _context.Projects.SingleOrDefault(x => x.Id == id);
        project.Cancel();
    }

    public void CreateComment(CreateCommentInputModel inputModel)
    {
        var comment = new ProjectComment(inputModel.Content, inputModel.ProjectId, inputModel.UserId);
        _context.ProjectComments.Add(comment);
    }

    public void Start(int id)
    {
        var project = _context.Projects.SingleOrDefault(x => x.Id == id);
        project.Start();
    }

    public void Finish(int id)
    {
        var project = _context.Projects.SingleOrDefault(x => x.Id == id);
        project.Finish();
    }
}