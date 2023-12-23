using VirtualPetCareApi.Database;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Repositories
{
    public class ActivityRepo : IActivity
    {
        private readonly GameDbContext _context;
        public ActivityRepo(GameDbContext context)
        {
            _context = context;
        }

        public Activity GetById(int Id)
        {
            return _context.Activities.FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Activity Activity)
        {
            _context.Activities.Add(Activity);
        }
    }
}
