using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly IProjectRepository _repository;

    public UpdateProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetById(request.Id);
        project.Update(request.Title, request.Description, request.TotalCost);
        await _repository.SaveChangesAsync();

        return Unit.Value;
    }
}