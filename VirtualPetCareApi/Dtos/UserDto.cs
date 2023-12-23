using System.ComponentModel.DataAnnotations;

namespace VirtualPetCareApi.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = $"Username can't be left blank {nameof(Username)}")]
        [StringLength(30, ErrorMessage = $"Username can't exceed 30 characters {nameof(Username)}")]
        public string Username { get; set; }

        [Required(ErrorMessage = $"Email can't be left blank {nameof(Email)}")]
        [StringLength(50, ErrorMessage = $"Email can't exceed 50 characters {nameof(Username)}")]
        public string Email { get; set; }

        [Required(ErrorMessage = $"Password can't be left blank {nameof(Password)}")]
        [StringLength(50, ErrorMessage = $"Password can't exceed 50 characters {nameof(Username)}")]
        public string Password { get; set; }
    }
}
