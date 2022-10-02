using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskManagementSystem.Entities.Enums;

namespace TaskManagementSystem.Entities.Models
{
    public class Task:TaskBase
    {
        public virtual User? User { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public IEnumerable<Comment>? Comments { get; set; }
    }
}
