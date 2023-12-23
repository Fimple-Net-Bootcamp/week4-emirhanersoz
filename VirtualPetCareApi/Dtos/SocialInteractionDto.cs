using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareApi.Dtos
{
    public class SocialInteractionDto
    {
        public int PetId { get; set; }

        [Required(ErrorMessage = $"Name can't be left blank {nameof(Name)}")]
        [StringLength(50, ErrorMessage = $"Name can't exceed 50 characters {nameof(Name)}")]
        public string Name { get; set; }

        [Required(ErrorMessage = $"Place can't be left blank {nameof(Place)}")]
        [StringLength(100, ErrorMessage = $"Place can't exceed 100 characters {nameof(Place)}")]
        public string Place { get; set; }

        [Required(ErrorMessage = $"Description can't be left blank {nameof(Description)}")]
        [StringLength(200, ErrorMessage = $"Description can't exceed 200 characters {nameof(Description)}")]
        public string Description { get; set; }
    }
}
