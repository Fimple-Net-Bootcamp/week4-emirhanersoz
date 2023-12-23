using System.Linq.Expressions;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Interface
{
    public interface IPet
    {
        List<Pet> GetAll();
        Pet GetById(int Id);
        void Insert(Pet Pet);
        void Update(Pet Pet);
    }
}
