using LearnASP.Core.Contracts;
using LearnASP.Dtos.User;
using LearnASP.Error;
using LearnASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LearnASP.Core.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserRepo(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User> GetById(string id)
        {
            var u = await _context.User.SingleOrDefaultAsync(u => u.id.ToString() == id);
            if (u != null)
            {
                return u;
            }
            else
            {
                throw new ApiException("User not found", 400);
            }
        }

        public async Task<(User, String)> Login(LoginDto loginDto)
        {
            var user = await _context.User.SingleOrDefaultAsync(u => u.username == loginDto.username && u.password == loginDto.password);

            if (user is null)
            {
                throw new ApiException("Wrong username or password", 400);
            }
            else
            {
                var token = GenerateToken(user);
                return (user, token);
            }
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                }),
                Expires = DateTime.Now.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
