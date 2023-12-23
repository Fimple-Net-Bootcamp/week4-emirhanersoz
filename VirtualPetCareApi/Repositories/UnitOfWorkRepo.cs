using VirtualPetCareApi.Database;
using VirtualPetCareApi.Interface;
using VirtualPetCareApi.Models;

namespace VirtualPetCareApi.Repositories
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly GameDbContext _context;
        private UserRepo _userRepo;
        private PetRepo _petRepo;
        private ActivityRepo _activityRepo;
        private HealthStatusRepo _healthStatusRepo;
        private FoodRepo _foodRepo;
        private TrainingRepo _trainingRepo;
        private SocialInteractionRepo _socialInteractionRepo;

        public UnitOfWorkRepo(GameDbContext context)
        {
            _context = context;
        }

        public IUser User
        {
            get
            {
                return _userRepo = _userRepo ?? new UserRepo(_context);
            }
        }

        public IPet Pet
        {
            get 
            { 
                return _petRepo = _petRepo ?? new PetRepo(_context); 
            } 
        }

        public IActivity Activity
        {
            get
            {
                return _activityRepo = _activityRepo ?? new ActivityRepo(_context);
            }
        }

        public IHealthStatus HealthStatus
        {
            get
            {
                return _healthStatusRepo = _healthStatusRepo ?? new HealthStatusRepo(_context);
            }
        }

        public IFood Food
        {
            get
            {
                return _foodRepo = _foodRepo ?? new FoodRepo(_context);
            }
        }

        public ITraining Training
        {
            get
            {
                return _trainingRepo = _trainingRepo ?? new TrainingRepo(_context);
            }
        }

        public ISocialInteraction SocialInteraction
        {
            get
            {
                return _socialInteractionRepo = _socialInteractionRepo ?? new SocialInteractionRepo(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
