using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Domain.Auth
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string Username, string password);
        Task<bool> UserExists(string username);
    }
}
