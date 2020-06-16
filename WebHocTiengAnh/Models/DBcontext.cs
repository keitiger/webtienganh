using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHocTiengAnh.Models.Configuration;

namespace WebHocTiengAnh.Models
{
    public class DBcontext : DbContext
    {
        public DBcontext( DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LessonExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserLessonConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<LessonExercise> LessonExercises { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        //Tuan//
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().ToTable("Answer");
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<ExerciseType>().ToTable("ExerciseType");
            modelBuilder.Entity<Lesson>().ToTable("LessonExercise");
            modelBuilder.Entity<LessonExercise>().ToTable("LessonExercise");
            modelBuilder.Entity<Topic>().ToTable("Topic");
            modelBuilder.Entity<User>().ToTable("User");
        }
        //End-Tuan//*/
    }
}
