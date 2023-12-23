using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace VirtualPetCareApi.Dtos
{
    public class TrainingDto
    {
        public int petId { get; set; }

        [Required(ErrorMessage = $"Name can't be left blank {nameof(Name)}")]
        [StringLength(50, ErrorMessage = $"Name can't exceed 50 characters {nameof(Name)}")]
        public string Name { get; set; }

        [Required(ErrorMessage = $"Fee can't be left blank {nameof(Fee)}")]
        public decimal Fee { get; set; }

        [Required(ErrorMessage = $"Duration can't be left blank {nameof(Duration)}")]
        public string Duration { get; set; }

        public TimeSpan GetDurationAsTimeSpan()
        {
            if (TimeSpan.TryParse(Duration, out TimeSpan result))
            {
                return result;
            }

            return TimeSpan.Zero;
        }
    }
}
