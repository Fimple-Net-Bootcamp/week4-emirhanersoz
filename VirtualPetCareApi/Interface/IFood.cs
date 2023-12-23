using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Interface
{
    public interface IFood
    {
        List<Food> GetAll();
        void Insert(Food Food);
    }
}
