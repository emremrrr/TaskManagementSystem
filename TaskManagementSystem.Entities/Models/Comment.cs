using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Entities.Enums;

namespace TaskManagementSystem.Entities.Models
{
    public class Comment : CommentBase
    {
        public User User { get; set; }
    }
}
