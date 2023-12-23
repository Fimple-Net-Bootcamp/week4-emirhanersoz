using VirtualPetCareApi.Database;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Repositories
{
    public class FoodRepo : IFood
    {
        private readonly GameDbContext _context;
        public FoodRepo(GameDbContext context)
        {
            _context = context;
        }

        public List<Food> GetAll()
        {
            return _context.Foods.ToList();
        }

        public void Insert(Food Food)
        {
            _context.Foods.Add(Food);
        }
    }
}
