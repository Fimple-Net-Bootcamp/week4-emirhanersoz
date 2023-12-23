using VirtualPetCareApi.Database;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Repositories
{
    public class PetRepo : IPet
    {
        private readonly GameDbContext _context;
        public PetRepo(GameDbContext context)
        {
            _context = context;
        }

        public List<Pet> GetAll()
        {
            return _context.Pets.ToList();
        }

        public Pet GetById(int Id)
        {
            return _context.Pets.FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Pet Pet)
        {
            _context.Pets.Add(Pet);
        }

        public void Update(Pet Pet)
        {
            _context.Pets.Update(Pet);
        }
    }
}
