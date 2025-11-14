using Coffee.Models;
using Coffee.Repositories;

public interface IUserRepository:IRepository<User>
{
    IEnumerable<User> GetUsers();
    User GetById(int Id);
    User GeByUserName(string userName);
    void Insert(User user);
    void Update(User user);
}

