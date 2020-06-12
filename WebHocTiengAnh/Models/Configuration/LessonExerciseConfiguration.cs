using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models.Configuration
{
    public class LessonExerciseConfiguration : IEntityTypeConfiguration<LessonExercise>
    {
        public void Configure(EntityTypeBuilder<LessonExercise> builder)
        {
            builder.ToTable("LessonExercises");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Lesson).WithMany(x => x.LessonExercises).HasForeignKey(x => x.LessonId);
            builder.HasOne(x => x.Exercise).WithMany(x => x.LessonExercises).HasForeignKey(x => x.ExerciseId);

        }
    }
}
