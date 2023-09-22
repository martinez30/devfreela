using DevFreela.Application.InputModels;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Queries.GetAllUserQuery;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserViewModel>>
{
    private readonly IUserRepository _repository;

    public GetAllUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserViewModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAll();
        
        return users
            .Select(x => new UserViewModel(x.Id, x.FullName, x.Email, x.CreatedAt, x.BirthDate))
            .ToList();
    }
}