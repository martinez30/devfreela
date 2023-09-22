using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Queries.GetAllProjectsQuery;

public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
{
    public string Name { get; set; }

    public GetAllProjectsQuery(string name)
    {
        Name = name;
    }
}