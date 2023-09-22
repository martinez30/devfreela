using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
{
    private readonly IProjectRepository _repository;

    public FinishProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetById(request.Id);

        if (project == null)
            return Unit.Value;

        await _repository.Finish(project);
        return Unit.Value;
    }
}