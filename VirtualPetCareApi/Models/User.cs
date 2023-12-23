using Microsoft.EntityFrameworkCore.ChangeTracking;
using VirtualPetCareApi.Entity;

namespace VirtualPetCareApi.Models
{
    public class User : Entity<int>
    {
        public  string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Pet> Pets { get; set; }
    }
}
