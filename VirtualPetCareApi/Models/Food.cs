using VirtualPetCareApi.Entity;

namespace VirtualPetCareApi.Models
{
    public class Food : Entity<int>
    {
        public string Name { get; set; }
        public int HealthBonus { get; set; }
        public int HungerReduction { get; set; }
        public DateTime ExpirationDate { get; set; }
        public virtual List<FoodPet> FoodPets { get; set; }
    }
}
