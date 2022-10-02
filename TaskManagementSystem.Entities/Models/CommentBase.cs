using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Entities.Enums;

namespace TaskManagementSystem.Entities.Models
{
    public class CommentBase:BaseModel
    {
        public string CommentText { get; set; }
        public CommentType CommentType { get; set; }
        public DateTime ReminderDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
