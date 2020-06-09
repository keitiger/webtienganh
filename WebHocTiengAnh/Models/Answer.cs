using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int AnswerText { get; set; }
    }
}
