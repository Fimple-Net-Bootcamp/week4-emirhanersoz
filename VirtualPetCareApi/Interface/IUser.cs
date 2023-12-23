using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Interface
{
    public interface IUser
    {     
        List<User> GetAll();
        User GetById(int userId);
        void Insert(User user);
    }
}
