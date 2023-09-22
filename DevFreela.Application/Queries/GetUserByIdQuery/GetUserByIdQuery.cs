using DevFreela.Application.InputModels;

namespace DevFreela.Application.Queries.GetUserByIdQuery;

public class GetUserByIdQuery : IRequest<UserViewModel>
{
    public int Id { get; set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}