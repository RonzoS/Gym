using System.ComponentModel.DataAnnotations;

namespace GymWeb.Model
{
    public class ExerciseSet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Boolean Done { get; set; }
        public ICollection<ExerciseSetRepeat> ExerciseSetRepeats { get; set; }

    }
}
