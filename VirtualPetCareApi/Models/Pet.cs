using System.ComponentModel.DataAnnotations.Schema;
using VirtualPetCareApi.Entity;

namespace VirtualPetCareApi.Models
{
    public class Pet : Entity<int>
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual HealthStatus HealthStatus { get; set; }
        public virtual List<ActivityPet> ActivityPets { get; set; }
        public virtual List<FoodPet> FoodPets { get; set; }
        public virtual List<Training> Trainings { get; set; }
        public virtual List<SocialInteraction> SocialInteractions { get; set; }
    }
}
