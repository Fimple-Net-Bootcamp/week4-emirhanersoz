using VirtualPetCareApi.Entity;

namespace VirtualPetCareApi.Models
{
    public class Activity : Entity<int>
    {
        public string Name { get; set; }
        public int HealthBonus { get; set; }
        public int HappinessBonus { get; set; }
        public int CleanlinessReduction { get; set; }
        public virtual List<ActivityPet> ActivityPets { get; set; }
    }
}
