namespace DevFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest<Unit>
{
    public int Id { get; private set; }

    public DeleteProjectCommand(int id)
    {
        Id = id;
    }
}