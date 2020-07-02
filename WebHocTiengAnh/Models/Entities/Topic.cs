using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHocTiengAnh.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string NameTopic { get; set; }
        public bool IsActive { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
