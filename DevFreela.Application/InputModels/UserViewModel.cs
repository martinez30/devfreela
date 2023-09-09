namespace DevFreela.Application.InputModels;

public class UserViewModel
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime BirthDate { get; set; }
    
    public UserViewModel(int id, string fullname, string email, DateTime createdAt, DateTime birthDate)
    {
        Id = id;
        Fullname = fullname;
        Email = email;
        CreatedAt = createdAt;
        BirthDate = birthDate;
    }
}