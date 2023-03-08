using System.ComponentModel.DataAnnotations;

namespace GymWeb.Model
{
    public class Tool
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ExerciseTool> ExerciseTools { get; set; }
    }
}