using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;

namespace DevFreela.Application.Queries.GetAllSkillQuery;

public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillQuery, List<SkillViewModel>>
{
    private readonly ISkillRepository _repository;

    public GetAllSkillQueryHandler(ISkillRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<SkillViewModel>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
    {
        var skills = await _repository.GetAll();
        
        var skillsViewModel = skills
            .Select(x => new SkillViewModel(x.Id, x.Description))
            .ToList();
        
        return skillsViewModel;
    }
}