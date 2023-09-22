using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly IProjectRepository _repository;

    public DeleteProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetById(request.Id);

        if (project == null)
            return Unit.Value;

        await _repository.Delete(project);
        return Unit.Value;
    }
}