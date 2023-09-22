using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.CreateComment;

public class CreateCommentCommand : IRequest<Unit>
{
    public string Content { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }
}

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly DevFreelaContext _context;

    public CreateCommentCommandHandler(DevFreelaContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.Content, request.ProjectId, request.UserId);
        await _context.ProjectComments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}