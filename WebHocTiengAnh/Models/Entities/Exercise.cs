using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public int ExerciseTypeId { get; set; }
        public int LessonId { get; set; }
        public string Question { get; set; }
        public string Media { get; set; }
        public string TrueAnswer { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public List<Answer> Answers { get; set; }
        public Lesson Lesson { get; set; }

    }
}
