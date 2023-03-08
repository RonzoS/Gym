namespace GymWeb.Model
{
    public class ExerciseSetRepeat
    {
        public int ExerciseSetId { get; set; }
        public int RepeatId { get; set; }
        public ExerciseSet ExerciseSet { get; set; }
        public Repeat Repeat { get; set; }

    }
}
