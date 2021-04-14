using System.Threading.Tasks;
using AspNetCoreDDD.Domain.Entities;
using AspNetCoreDDD.Domain.Interfaces;

namespace AspNetCoreDDD.Domain.Repository
{
    public interface IUserRepository: IRepository<UserEntity>
    {
         Task<UserEntity> FindByLogin(string email);
    }
}