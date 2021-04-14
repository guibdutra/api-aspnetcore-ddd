using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;
using AspNetCoreDDD.Domain.Dto.Login;
using AspNetCoreDDD.Domain.Entities;
using AspNetCoreDDD.Domain.Interfaces.Services.User;
using AspNetCoreDDD.Domain.Repository;
using AspNetCoreDDD.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AspNetCoreDDD.Infrastructure.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository repository;
        private SigningConfigurations signingConfigurations;
        private TokenConfigurations tokenConfigurations;
        public LoginService(IConfiguration configuration) 
        {
            this.configuration = configuration;
               
        }
                public IConfiguration configuration { get; }

        public LoginService(
                            IUserRepository repository,
                            SigningConfigurations signingConfigurations,
                            TokenConfigurations tokenConfigurations,
                            IConfiguration configuration)
        {
            this.repository = repository;
            this.signingConfigurations = signingConfigurations;
            this.tokenConfigurations = tokenConfigurations;
            this.configuration = configuration;
        }

        public async Task<object> Authenticate(LoginDto user)
        {
            var baseUser = new UserEntity();

            if (user != null && !string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Password))
            {
                try
                {
                    baseUser = await repository.FindByLogin(user.Email);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR_SERVICE: " + ex.Message);
                }

                if (baseUser != null && new DealingHash(new SHA512Managed()).CheckHash(user.Password, baseUser.Password))
                {
                    return SuccessObject(user.Email);
                }

                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "E-mail não encontrado."
                    };
                }
                if (baseUser.Password != user.Password)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Senha incorreta."
                    };
                }
            }
            return new
            {
                authenticated = false,
                message = "Authentication failed. "
            };
        }
        
        private object SuccessObject(string email)
        {
            var identity = new ClaimsIdentity(
                new GenericIdentity(email),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // jti token ID
                    new Claim(JwtRegisteredClaimNames.UniqueName, email),
                }
            );

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            string token = CreateToken(identity, createDate, expirationDate, handler);

            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                accessToken = token,
                userName = email,
                message = "User success logged."
            };
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredencials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }
    }
}
