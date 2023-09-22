using DevFreela.Application.InputModels;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Queries.GetUserByIdQuery;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
{
    private readonly IUserRepository _repository;

    public GetUserByIdQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.Id);

        if (user == null)
        {
            return null;
        }

        var userViewModel = new UserViewModel(user.Id, user.FullName, user.Email, user.CreatedAt, user.BirthDate);

        return userViewModel;
    }
}