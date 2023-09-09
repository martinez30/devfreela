using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly DevFreelaContext _context;

    public UserService(DevFreelaContext context)
    {
        _context = context;
    }

    public int Create(NewUserInputModel inputModel)
    {
        var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
        _context.Users.Add(user);
        return user.Id;
    }

    public void Update(UpdateUserInputModel inputModel)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == inputModel.Id);
        user.Update(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
    }

    public List<UserViewModel> GetAll(string query)
    {
        var users = _context.Users;
        return users
            .Select(x => new UserViewModel(x.Id, x.FullName, x.Email, x.CreatedAt, x.BirthDate))
            .ToList();
    }

    public UserViewModel GetById(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);
        return new UserViewModel(user.Id, user.FullName, user.Email, user.CreatedAt, user.BirthDate);
    }
}