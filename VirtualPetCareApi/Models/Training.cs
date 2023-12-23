using VirtualPetCareApi.Entity;

namespace VirtualPetCareApi.Models
{
    public class Training : Entity<int>
    {
        public string Name { get; set; }
        public decimal Fee { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
