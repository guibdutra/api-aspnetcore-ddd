using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreDDD.Domain.Dto.User;

namespace AspNetCoreDDD.Domain.Interfaces.Services.User
{
    public interface IUserService {
        Task<UserDto> Get (Guid id);
        Task<bool> Exist (Guid id);
        Task<bool> IsValidEmail (string email, Guid userId);
        Task<IEnumerable<UserDto>> GetAll ();
        Task<UserDtoCreateResult> Post (UserDtoCreate user);
        Task<UserDtoUpdateResult> Put (UserDtoUpdate user);
        Task<bool> Delete (Guid id);
    }
}