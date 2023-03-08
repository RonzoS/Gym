using GymWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace GymWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseSet> ExerciseSet { get; set; }
        public DbSet<Muscle> Muscle { get; set; }
        public DbSet<Repeat> Repeat { get; set; }
        public DbSet<Tool> Tool { get; set; }
        public DbSet<ExerciseMuscle> ExerciseMuscle { get; set; }
        public DbSet<ExerciseTool> ExerciseTool { get; set; }
        public DbSet<ExerciseSetRepeat> RepeatExercise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseMuscle>()
                .HasKey(em => new { em.ExerciseId, em.MuscleId });
            modelBuilder.Entity<ExerciseMuscle>()
                .HasOne(e => e.Exercise)
                .WithMany(em => em.ExerciseMuscles)
                .HasForeignKey(e => e.ExerciseId);
            modelBuilder.Entity<ExerciseMuscle>()
                .HasOne(m => m.Muscle)
                .WithMany(em => em.ExerciseMuscles)
                .HasForeignKey(m => m.MuscleId);

            modelBuilder.Entity<ExerciseTool>()
                .HasKey(et => new { et.ExerciseId, et.ToolId });
            modelBuilder.Entity<ExerciseTool>()
                .HasOne(e => e.Exercise)
                .WithMany(et => et.ExerciseTools)
                .HasForeignKey(e => e.ExerciseId);
            modelBuilder.Entity<ExerciseTool>()
                .HasOne(t => t.Tool)
                .WithMany(et => et.ExerciseTools)
                .HasForeignKey(t => t.ToolId);

            modelBuilder.Entity<ExerciseSetRepeat>()
                .HasKey(er => new { er.ExerciseSetId, er.RepeatId });
            modelBuilder.Entity<ExerciseSetRepeat>()
                .HasOne(e => e.ExerciseSet)
                .WithMany(er => er.ExerciseSetRepeats)
                .HasForeignKey(e => e.ExerciseSetId);
            modelBuilder.Entity<ExerciseSetRepeat>()
                .HasOne(r => r.Repeat)
                .WithMany(er => er.ExerciseSetRepeats)
                .HasForeignKey(r => r.RepeatId);

        }

    }
}

