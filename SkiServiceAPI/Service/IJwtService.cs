using SkiServiceAPI.Models;

namespace SkiServiceAPI.Service
{
    public interface IJwtService
    {
        string CreateToken(string username);
        List<User> Login();
    }
}
