using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaContext _context;

    public ProjectRepository(DevFreelaContext context)
    {
        _context = context;
    }

    public async Task<Project> GetById(int id)
    {
        return await _context.Projects
            .Include(x => x.Client)
            .Include(x => x.Freelancer)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Project>> GetAll()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task CreateProject(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
    }

    public async Task CreateComment(ProjectComment projectComment)
    {
        await _context.ProjectComments.AddAsync(projectComment);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Start(Project project)
    {
        project.Start();
        await _context.SaveChangesAsync();
    }

    public async Task Finish(Project project)
    {
        project.Finish();
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Project project)
    {
        project.Cancel();
        await _context.SaveChangesAsync();
    }
}