using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models
{
    public class User
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
