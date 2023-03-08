using System.ComponentModel.DataAnnotations;

namespace GymWeb.Model
{
    public class Repeat
    {
        [Key]
        public int Id { get; set; }
        public int FirstRepeats { get; set; }
        public float FirstWeight { get; set; }
        public int SecoundRepeats { get; set; }
        public float SecoundWeight { get; set; }
        public int ThirdRepeats { get; set; }
        public float ThirdWeight { get; set; }
        public int FourthRepeats { get; set; }
        public float FourthWeight { get; set; }
        public Exercise Exercise { get; set; }
        public ICollection<ExerciseSetRepeat> ExerciseSetRepeats { get; set; }

    }
}
