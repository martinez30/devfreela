using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Queries.GetProjectByIdQuery;

public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
{
    public int Id { get; set; }

    public GetProjectByIdQuery(int id)
    {
        Id = id;
    }
}