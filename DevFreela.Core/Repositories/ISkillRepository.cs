using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface ISkillRepository
{
    Task<Skill> GetById(int id);
    Task<List<Skill>> GetAll();
}