namespace DevFreela.Core.Entities;

public class UserSkill : BaseEntity
{
    public int UserId { get; private set; }
    public User User { get; private set; }
    
    public int SkillId { get; private set; }
    public Skill Skill { get; private set; }

    protected UserSkill() {}
    
    public UserSkill(int userId, int skillid)
    {
        UserId = userId;
        SkillId = skillid;
    }
}