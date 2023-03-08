using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GymWeb.Repository
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        private readonly ApplicationDbContext _db;
        public ExerciseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Add(Exercise exercise, int MuscleId, int ToolId)
        {
            var ExersiseMuscleEntity = _db.Muscle.Where(m => m.Id == MuscleId).FirstOrDefault();
            var ExersiseToolEntity = _db.Tool.Where(t => t.Id == ToolId).FirstOrDefault();

            var EcersiseMuscle = new ExerciseMuscle()
            {
                Exercise = exercise,
                Muscle = ExersiseMuscleEntity,
            };
            var EcersiseTool = new ExerciseTool()
            {
                Exercise = exercise,
                Tool = ExersiseToolEntity,
            };
            _db.Add(EcersiseMuscle);
            _db.Add(EcersiseTool);
            _db.Add(exercise);

        }

        public ICollection<Muscle> GetMuscleByExercise(int exerciseId)
        {
            return _db.ExerciseMuscle.Where(e => e.Exercise.Id == exerciseId).Select(m => m.Muscle).ToList();
        }

        public ICollection<Tool> GetToolByExercise(int exerciseId)
        {
            return _db.ExerciseTool.Where(e => e.Exercise.Id == exerciseId).Select(m => m.Tool).ToList();
        }

        public void Update(Exercise exercise)
        {
            var objFromDb = _db.Exercise.FirstOrDefault(u => u.Id == exercise.Id);
            objFromDb.Name = exercise.Name;
            objFromDb.Description = exercise.Description;
            objFromDb.Clues = exercise.Clues;
            if(objFromDb.Image != null)
            {
                objFromDb.Image = exercise.Image;
            }
        }
    }
}
