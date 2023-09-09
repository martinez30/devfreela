using DevFreela.Application.InputModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    int Create(NewUserInputModel inputModel);
    void Update(UpdateUserInputModel inputModel);
    List<UserViewModel> GetAll(string query);
    UserViewModel GetById(int id);
}