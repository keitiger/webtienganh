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
        public int Question { get; set; }
        public int Media { get; set; }
        public int TrueAnswer { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public List<Answer> Answers { get; set; }
        public List<LessonExercise> LessonExercises { get; set; }

    }
}
