using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareApi.Dtos
{
    public class ActivityDto
    {
        public int PetId { get; set; } 

        [Required(ErrorMessage = $"Name can't be left blank {nameof(Name)}")]
        [StringLength(50, ErrorMessage = $"Name can't exceed 50 characters {nameof(Name)}")]
        public string Name { get; set; }

        [Required(ErrorMessage = $"HealthBonus can't be left blank {nameof(HealthBonus)}")]
        [Range(0, 100, ErrorMessage = $"HealthBonus must be between 0 and 100 {nameof(HealthBonus)}")]
        public int HealthBonus { get; set; }

        [Required(ErrorMessage = $"HappinessBonus can't be left blank {nameof(HappinessBonus)}")]
        [Range(0, 100, ErrorMessage = $"HappinessBonus must be between 0 and 100 {nameof(HappinessBonus)}")]
        public int HappinessBonus { get; set; }

        [Required(ErrorMessage = $"CleanlinessReduction can't be left blank {nameof(CleanlinessReduction)}")]
        [Range(0, 100, ErrorMessage = $"CleanlinessReduction must be between 0 and 100 {nameof(CleanlinessReduction)}")]
        public int CleanlinessReduction { get; set; }
    }
}
