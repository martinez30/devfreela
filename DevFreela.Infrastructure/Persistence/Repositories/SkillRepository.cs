using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly DevFreelaContext _context;

    public SkillRepository(DevFreelaContext context)
    {
        _context = context;
    }

    public Task<Skill> GetById(int id)
    {
        return _context.Skills.SingleOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<Skill>> GetAll()
    {
        return _context.Skills.ToListAsync();
    }
}