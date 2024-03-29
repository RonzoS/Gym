﻿using System.ComponentModel.DataAnnotations;

namespace GymWeb.Model
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }   
        [Required]
        public string Description { get; set; }
        public string Clues { get; set; }
        public string Image { get; set; }
        [Display(Name = "Tools")]
        public ICollection<ExerciseTool> ExerciseTools { get; set; }
        [Display(Name = "Muscles")]
        public ICollection<ExerciseMuscle> ExerciseMuscles { get; set; }
        public ICollection<Repeat> Repeats{ get; set; }

    }
}
