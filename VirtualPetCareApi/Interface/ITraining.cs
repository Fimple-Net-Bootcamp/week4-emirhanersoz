using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Interface
{
    public interface ITraining
    {
        List<Training> GetAll();
        Training GetById(int Id);
        void Insert(Training Training);
    }
}
