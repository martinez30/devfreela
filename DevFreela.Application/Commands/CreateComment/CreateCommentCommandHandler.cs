using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly IProjectRepository _repository;

    public CreateCommentCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.Content, request.ProjectId, request.UserId);
        await _repository.CreateComment(comment);

        return Unit.Value;
    }
}