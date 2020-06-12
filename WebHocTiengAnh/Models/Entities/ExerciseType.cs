using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models
{
    public class ExerciseType
    {
        public int Id { get; set; }
        public int NameExerciseType { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
