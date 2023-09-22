using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetById(int id);

    Task Create(User user);
}