using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHocTiengAnh.Models.Entities;

namespace WebHocTiengAnh.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string NameLesson { get; set; }
        public int RequireExp { get; set; }
        public Topic Topic { get; set; }
        public List<LessonExercise> LessonExercises { get; set; }
        public List<UserLesson> UserLessons { get; set; }
    }
}
