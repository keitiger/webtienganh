using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHocTiengAnh.Models.Entities;

namespace WebHocTiengAnh.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<UserLesson> UserLessons { get; set; }
    }
}
