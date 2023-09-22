using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly IUserRepository _repository;

    public CreateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.FullName, request.Email, request.BirthDate);
        await _repository.Create(user);

        return Unit.Value;
    }
}