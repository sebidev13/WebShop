using WebShopServiceWebsline.Helper;
using WebShopServiceWebsline.Interfaces;
using WebShopServiceWebsline.Models;

namespace WebShopServiceWebsline.Repository;

public class UserRepository : IUserRepository
{
    private readonly DummyData _context;
    
    public UserRepository() 
    {
        _context = DummyData.Instance; 
    }

    public ICollection<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUser(int userId)
    {
        return _context.Users.FirstOrDefault(u => u.UserId.Equals(userId));   
    }

    public User GetUser(string userName)
    {
        return _context.Users.Where(u => u.Username.Equals(userName)).FirstOrDefault();
    }

    public bool UserExists(int userId)
    {
        return _context.Users.Any(u => u.UserId.Equals(userId));
    }

    public bool CreateUser(User user)
    {
        _context.Users.Add(user);

        if (_context.Users.Contains(user))
            return true;

        return false;

    }

    public bool UpdateUser(User user)
    {
        var item = _context.Users.Find(u => u.UserId.Equals(user.UserId));

        if(item != null)
        {
            item.ShoppingCart = user.ShoppingCart;
            item.Username = user.Username;
            item.Password = user.Password;
                
            return true;    
        }
        return false;
    }

    public bool DeleteUser(User user)
    {
        var item = _context.Users.Find(u => u.UserId.Equals(user.UserId));

        if(item != null)
        {
            _context.Users.Remove(item);
                
            if(_context.Users.Contains(item))
                return false;

            return true;
        }
        return false;
    }
}