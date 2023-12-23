using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareApi.Dtos
{
    public class HealthStatusDto
    {
        public int PetId { get; set; }

        [Required(ErrorMessage = $"Health can't be left blank {nameof(Health)}")]
        [Range(0, 100, ErrorMessage = $"Health must be between 0 and 100 {nameof(Health)}")]
        public int Health { get; set; }

        [Required(ErrorMessage = $"HappinessLevel can't be left blank {nameof(HappinessLevel)}")]
        [Range(0, 100, ErrorMessage = $"HappinessLevel must be between 0 and 100 {nameof(HappinessLevel)}")]
        public int HappinessLevel { get; set; }

        [Required(ErrorMessage = $"HungerLevel can't be left blank {nameof(HungerLevel)}")]
        [Range(0, 100, ErrorMessage = $"HungerLevel must be between 0 and 100 {nameof(HungerLevel)}")]
        public int HungerLevel { get; set; }

        [Required(ErrorMessage = $"CleanlinessLevel can't be left blank {nameof(CleanlinessLevel)}")]
        [Range(0, 100, ErrorMessage = $"CleanlinessLevel must be between 0 and 100 {nameof(CleanlinessLevel)}")]
        public int CleanlinessLevel { get; set; }
    }
}
