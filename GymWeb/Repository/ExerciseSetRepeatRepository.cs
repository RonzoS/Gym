using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;

namespace GymWeb.Repository
{
    public class ExerciseSetRepeatRepository : Repository<ExerciseSetRepeat>, IExerciseSetRepeatRepository
    {
        private readonly ApplicationDbContext _db;
        public ExerciseSetRepeatRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}