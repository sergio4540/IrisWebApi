using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTalentu.Models
{
    public class Activities
    {
        [Key]
        public int IdActivity { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public int IdCategory { get; set; }
        public bool IsCompleted { get; set; }
    }
}
