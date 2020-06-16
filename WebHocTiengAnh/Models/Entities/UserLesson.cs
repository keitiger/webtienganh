using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models.Entities
{
    public class UserLesson
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public User User { get; set; }
        public Lesson Lesson{ get; set; }
    }
}
