using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Queries.GetProjectByIdQuery;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
{
    private readonly IProjectRepository _repository;

    public GetProjectByIdQueryHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async  Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetById(request.Id);
        
        return new ProjectDetailsViewModel(
            project.Id,
            project.Title,
            project.Description,
            project.TotalCost,
            project.StartedAt,
            project.FinishedAt,
            project.Client.FullName,
            project.Freelancer.FullName
        );
    }
}