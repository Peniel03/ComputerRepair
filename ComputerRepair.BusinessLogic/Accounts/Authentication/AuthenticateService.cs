using ComputerRepair.BusinessLogic.Exceptions;
using ComputerRepair.BusinessLogic.Interfaces;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ComputerRepair.BusinessLogic.Accounts.Token;

namespace ComputerRepair.BusinessLogic.Accounts.Authentication
{
 
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public AuthenticateService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public async Task<Tokens> Authenticate(string email, string password)
        {
            var _user = await ValidateUserAsync(email, password);

            //we have Authenticated
            //Generate Json Web Token 
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email ,email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

        public async Task<User> ValidateUserAsync(string email, string password)
        {
            var userLooked = await _userRepository.GetUserByEmailAsync(email);

            if (userLooked is null || userLooked.Password == password)
            {
                throw new NotFoundException("This user does exist");
            }

            return userLooked;
        }

             
    }
}
