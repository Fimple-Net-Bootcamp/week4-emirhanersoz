using VirtualPetCareApi.Database;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Repositories
{
    public class TrainingRepo : ITraining
    {
        private readonly GameDbContext _context;
        public TrainingRepo(GameDbContext context)
        {
            _context = context;
        }

        public List<Training> GetAll()
        {
            return _context.Trainings.ToList();
        }

        public Training GetById(int Id)
        {
            return _context.Trainings.FirstOrDefault(x => x.Id == Id);
        }

        public void Insert(Training Training)
        {
            _context.Trainings.Add(Training);
        }
    }
}
