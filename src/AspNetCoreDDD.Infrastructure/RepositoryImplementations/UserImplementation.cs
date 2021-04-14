using System.Threading.Tasks;
using AspNetCoreDDD.Domain.Entities;
using AspNetCoreDDD.Domain.Repository;
using AspNetCoreDDD.Infrastructure.Context;
using AspNetCoreDDD.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDDD.Infrastructure.RepositoryImplementations
{
    public class UserImplementation: BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await dataset.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}