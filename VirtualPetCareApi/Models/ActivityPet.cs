using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPetCareApi.Models
{
    public class ActivityPet
    {
        public int ActivityId { get; set; }
        public int PetId { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
