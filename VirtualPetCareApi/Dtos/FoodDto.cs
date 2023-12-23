using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareApi.Dtos
{
    public class FoodDto
    {
        [Required(ErrorMessage = $"Name can't be left blank {nameof(Name)}")]
        [StringLength(50, ErrorMessage = $"Name can't exceed 50 characters {nameof(Name)}")]
        public string Name { get; set; }

        [Required(ErrorMessage = $"HealthBonus can't be left blank {nameof(HealthBonus)}")]
        [Range(0, 100, ErrorMessage = $"HealthBonus must be between 0 and 100 {nameof(HealthBonus)}")]
        public int HealthBonus { get; set; }

        [Required(ErrorMessage = $"HungerReduction can't be left blank {nameof(HungerReduction)}")]
        [Range(0, 100, ErrorMessage = $"HungerReduction must be between 0 and 100 {nameof(HungerReduction)}")]
        public int HungerReduction { get; set; }

        [Required(ErrorMessage = $"ExpirationDate can't be left blank {nameof(ExpirationDate)}")]
        public DateTime ExpirationDate { get; set; }
    }
}
