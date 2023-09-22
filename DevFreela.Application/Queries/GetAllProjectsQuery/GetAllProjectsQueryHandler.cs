using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Queries.GetAllProjectsQuery;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
{
    private readonly IProjectRepository _repository;

    public GetAllProjectsQueryHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAll();
        
        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

        return projectsViewModel;
    }
}