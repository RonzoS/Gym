using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;

namespace GymWeb.Repository
{
    public class ExerciseToolRepository : Repository<ExerciseTool>, IExerciseToolRepository
    {
        private readonly ApplicationDbContext _db;
        public ExerciseToolRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}