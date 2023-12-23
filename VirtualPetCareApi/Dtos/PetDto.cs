using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareApi.Dtos
{
    public class PetDto
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = $"Name can't be left blank {nameof(Name)}")]
        [StringLength(50, ErrorMessage = $"Name can't exceed 50 characters {nameof(Name)}")]
        public string Name { get; set; }

        [Required(ErrorMessage = $"Species can't be left blank {nameof(Species)}")]
        [StringLength(50, ErrorMessage = $"Species can't exceed 50 characters {nameof(Species)}")]
        public string Species { get; set; }

        [Required(ErrorMessage = $"Age can't be left blank {nameof(Age)}")]
        [Range(0,150, ErrorMessage = $"Age must be between 0 and 150 {nameof(Age)}")]
        public int Age { get; set; }
    }
}
