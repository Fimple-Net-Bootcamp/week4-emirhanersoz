using VirtualPetCareApi.Database;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Repositories
{
    public class SocialInteractionRepo : ISocialInteraction
    {
        private readonly GameDbContext _context;
        public SocialInteractionRepo(GameDbContext context)
        {
            _context = context;
        }

        List<SocialInteraction> ISocialInteraction.GetAll()
        {
            return _context.SocialInteractions.ToList();
        }
        SocialInteraction ISocialInteraction.GetById(int Id)
        {
            return _context.SocialInteractions.FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(SocialInteraction SocialInteraction)
        {
            _context.SocialInteractions.Add(SocialInteraction);
        }
    }
}
