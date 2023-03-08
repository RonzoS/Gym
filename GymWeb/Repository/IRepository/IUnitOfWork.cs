namespace GymWeb.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IMuscleRepository Muscle { get; }
        IToolRepository Tool { get; }
        IExerciseRepository Exercise { get; }
        IExerciseMuscleRepository ExerciseMuscle { get; }
        IExerciseSetRepeatRepository ExerciseSetRepeat { get; }
        IExerciseToolRepository ExerciseTool { get; }
        void Save();
    }
}
