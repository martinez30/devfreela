using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.StartProject;

public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
{
    private readonly IProjectRepository _repository;

    public StartProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetById(request.Id);

        if (project == null)
            return Unit.Value;

        await _repository.Start(project);
        return Unit.Value;
    }
}