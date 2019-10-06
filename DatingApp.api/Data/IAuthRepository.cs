using System.Threading.Tasks;
using DatingApp.api.Models;

namespace DatingApp.api.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user ,string password);
         Task<User> Login(string UserName , string password);
         Task<bool> UserExists(string UserName);
    }
}