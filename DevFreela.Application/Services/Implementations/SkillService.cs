using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly DevFreelaContext _context;

    public SkillService(DevFreelaContext context)
    {
        _context = context;
    }

    public List<SkillViewModel> GetAll()
    {
        var skills = _context.Skills;
        var skillsViewModel = skills
            .Select(x => new SkillViewModel(x.Id, x.Description))
            .ToList();
        
        return skillsViewModel;
    }
}