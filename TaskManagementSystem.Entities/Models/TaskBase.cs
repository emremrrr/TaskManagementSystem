using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskManagementSystem.Entities.Enums;

namespace TaskManagementSystem.Entities.Models
{
    public class TaskBase: BaseModel
    {
        public DateTime RequiredDate { get; set; }
        public string TaskDescription { get; set; }
        public Enums.TaskStatus TaskStatus { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TaskType TaskType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int AssignedTo { get; set; }
        public DateTime NextActionDate { get; set; }

    }
}
