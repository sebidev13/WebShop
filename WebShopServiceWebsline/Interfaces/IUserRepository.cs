using WebShopServiceWebsline.Models;

namespace WebShopServiceWebsline.Interfaces;

public interface IUserRepository
{
    ICollection<User> GetUsers(); 
    User GetUser(int userId);
    User GetUser(string userName);
    bool UserExists(int userId);
    bool CreateUser(User user);
    bool UpdateUser(User user);
    bool DeleteUser(User user);
}