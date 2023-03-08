using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;

namespace GymWeb.Repository
{
    public class ExerciseMuscleRepository : Repository<ExerciseMuscle>, IExerciseMuscleRepository
    {
        private readonly ApplicationDbContext _db;
        public ExerciseMuscleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}