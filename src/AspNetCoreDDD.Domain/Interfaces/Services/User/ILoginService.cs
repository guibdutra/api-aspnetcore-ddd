using System.Threading.Tasks;
using AspNetCoreDDD.Domain.Dto.Login;

namespace AspNetCoreDDD.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> Authenticate(LoginDto user);
    }
}