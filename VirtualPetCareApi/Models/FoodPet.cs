namespace VirtualPetCareApi.Models
{
    public class FoodPet
    {
        public int FoodId { get; set; }
        public int PetId { get; set; }
        public virtual Food Food { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
