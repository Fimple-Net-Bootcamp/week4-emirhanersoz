using VirtualPetCareApi.Database;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Repositories
{
    public class UserRepo : IUser
    {
        private readonly GameDbContext _context;

        public UserRepo(GameDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public void Insert(User user)
        {
            _context.Users.Add(user);
        }
    }
}
