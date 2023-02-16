using LearnASP.Dtos.User;
using LearnASP.Models;

namespace LearnASP.Core.Contracts
{
    public interface IUserRepo
    {
        public Task<(User,String)> Login(LoginDto loginDto);
        public Task<User> GetById(string id);
    }
}
