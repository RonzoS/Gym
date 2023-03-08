namespace GymWeb.Model
{
    public class ExerciseTool
    {
        public int ExerciseId { get; set; }
        public int ToolId { get; set; }
        public Exercise Exercise { get; set; }
        public Tool Tool { get; set; }
    }
}
