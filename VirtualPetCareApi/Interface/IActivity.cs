using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Interface
{
    public interface IActivity
    {
        Activity GetById(int Id);
        void Insert(Activity Activity);
    }
}
