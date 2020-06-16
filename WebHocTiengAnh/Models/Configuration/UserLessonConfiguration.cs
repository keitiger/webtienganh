using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHocTiengAnh.Models.Entities;

namespace WebHocTiengAnh.Models.Configuration
{
    public class UserLessonConfiguration : IEntityTypeConfiguration<UserLesson>
    {
        public void Configure(EntityTypeBuilder<UserLesson> builder)
        {
            builder.ToTable("UserLessons");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Lesson).WithMany(x => x.UserLessons).HasForeignKey(x => x.LessonId);
            builder.HasOne(x => x.User).WithMany(x => x.UserLessons).HasForeignKey(x => x.UserId);
        }
    }
}
