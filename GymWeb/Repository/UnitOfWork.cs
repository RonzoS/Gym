using GymWeb.Data;
using GymWeb.Repository.IRepository;

namespace GymWeb.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Muscle = new MuscleRepository(_db);
            Tool = new ToolRepository(_db);
            Exercise = new ExerciseRepository(_db);
            ExerciseMuscle = new ExerciseMuscleRepository(_db);
            ExerciseTool = new ExerciseToolRepository(_db);
            ExerciseSetRepeat = new ExerciseSetRepeatRepository(_db);
        }

        public IMuscleRepository Muscle { get; private set; }
        public IToolRepository Tool { get; private set;}
        public IExerciseRepository Exercise { get; private set; }
        public IExerciseMuscleRepository ExerciseMuscle { get; private set; }   
        public IExerciseToolRepository ExerciseTool { get; private set; }
        public IExerciseSetRepeatRepository ExerciseSetRepeat { get; private set;}

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
