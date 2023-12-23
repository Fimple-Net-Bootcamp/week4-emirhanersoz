using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Interface
{
    public interface IUnitOfWork
    {
        IUser User { get; }
        IPet Pet { get; }
        IActivity Activity { get; }
        IHealthStatus HealthStatus { get; }
        IFood Food { get; }
        ITraining Training { get; }
        ISocialInteraction SocialInteraction { get; }
        void Save();
    }
}
