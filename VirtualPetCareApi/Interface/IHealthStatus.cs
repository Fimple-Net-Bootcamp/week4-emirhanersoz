using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Interface
{
    public interface IHealthStatus
    {
        HealthStatus GetByPetId(int id);
        void Update(HealthStatus healthStatus);
    }
}
