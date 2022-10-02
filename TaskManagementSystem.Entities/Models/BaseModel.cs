using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManagementSystem.Entities.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            
        }
        [Key]
        public int Id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Created { get; set; }

    }

}
