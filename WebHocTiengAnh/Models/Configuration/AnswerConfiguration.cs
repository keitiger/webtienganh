using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models.Configuration
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers");
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.ExerciseId).IsRequired(true);
            builder.HasOne(x => x.Exercise).WithMany(x => x.Answers).HasForeignKey(x => x.ExerciseId);
        }
    }
}
