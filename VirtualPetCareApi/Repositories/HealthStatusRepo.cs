using Microsoft.EntityFrameworkCore;
using VirtualPetCareApi.Database;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Repositories
{
    public class HealthStatusRepo : IHealthStatus
    {
        private readonly GameDbContext _context;
        public HealthStatusRepo(GameDbContext context)
        {
            _context = context;
        }

        public HealthStatus GetByPetId(int petId)
        {
            return _context.HealthStatuses.Include(hs => hs.Pet).FirstOrDefault(x => x.PetId == petId);
        }

        public void Update(HealthStatus HealthStatus)
        {
            _context.HealthStatuses.Update(HealthStatus);
        }
    }
}
