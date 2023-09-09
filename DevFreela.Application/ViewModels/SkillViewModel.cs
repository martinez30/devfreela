namespace DevFreela.Application.ViewModels;

public class SkillViewModel
{
    public int id { get; set; }
    public string Descricao { get; set; }

    public SkillViewModel(int id, string descricao)
    {
        this.id = id;
        Descricao = descricao;
    }
}