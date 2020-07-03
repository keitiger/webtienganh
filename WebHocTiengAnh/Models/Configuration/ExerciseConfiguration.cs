using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models.Configuration
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ExerciseType).WithMany(x => x.Exercises).HasForeignKey(x => x.ExerciseTypeId);
            builder.HasOne(x => x.Lesson).WithMany(x => x.Exercises).HasForeignKey(x => x.LessonId);
        }
    }
}
