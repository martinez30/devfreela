using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
    Task<Project> GetById(int id);
    Task<List<Project>> GetAll();

    Task CreateProject(Project project);
    Task CreateComment(ProjectComment projectComment);
    
    Task SaveChangesAsync();
    Task Start(Project project);
    Task Finish(Project project);
    Task Delete(Project project);
}