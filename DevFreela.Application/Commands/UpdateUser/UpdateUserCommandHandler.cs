namespace DevFreela.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly DevFreelaContext _dbContext;

    public UpdateUserCommandHandler(DevFreelaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.Id);
        user.Update(request.FullName, request.Email, request.BirthDate);
        await _dbContext.SaveChangesAsync();

        return Unit.Value;
    }
}