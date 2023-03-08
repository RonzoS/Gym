
namespace GymWeb.Model
{
    public class ExerciseMuscle
    {
        public int ExerciseId { get; set; }
        public int MuscleId { get; set; }
        public Exercise Exercise { get; set; }
        public Muscle Muscle { get; set; }
    }
}
