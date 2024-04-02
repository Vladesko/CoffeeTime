using DomainApp.Models;

namespace App.Interfaces
{
    public interface IJwtProvider
    {
        string CreateToken(User user);
    }
}
