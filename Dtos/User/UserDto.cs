using LearnASP.Models;

namespace LearnASP.Dtos.User
{
    public class UserDto
    {
        public Guid id { get; set; }
        public String username { get; set; } = null!;
        public String password { get; set; } = null!;
        public String name { get; set; } = null!;
        public String? address { get; set; }
        public ICollection<Bill> bills { get; set; }

        public UserDto()
        {
            bills = new List<Bill>();
        }
    }
}
