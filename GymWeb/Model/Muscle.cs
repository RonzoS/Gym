using System.ComponentModel.DataAnnotations;

namespace GymWeb.Model
{
    public class Muscle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ExerciseMuscle> ExerciseMuscles { get; set; }
        
    }
}
