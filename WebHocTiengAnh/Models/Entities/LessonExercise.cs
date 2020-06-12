using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models
{
    public class LessonExercise
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int ExerciseId { get; set; }
        public Lesson Lesson { get; set; }
        public Exercise Exercise{ get; set; }
    }
}
