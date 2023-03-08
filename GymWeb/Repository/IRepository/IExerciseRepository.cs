using GymWeb.Model;

namespace GymWeb.Repository.IRepository
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        void Update(Exercise exercise);
        void Add(Exercise exercise, int MuscleId, int ToolId);
        ICollection<Muscle> GetMuscleByExercise(int exerciseId);
        ICollection<Tool> GetToolByExercise(int exerciseId);
    }
}
