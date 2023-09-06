namespace DevFreela.Core.Entities;

public class UserSkill
{
    public int UserId { get; private set; }
    public int SkillId { get; private set; }

    public UserSkill(int userId, int skillid)
    {
        UserId = userId;
        SkillId = skillid;
    }
}