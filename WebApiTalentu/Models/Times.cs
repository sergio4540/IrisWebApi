using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTalentu.Models
{
    public class Times
    {
        [Key]
        public int IdTime { get; set; }
        public int TimeWork { get; set; }
        public DateTime? Date { get; set; }
        public int IdActivity { get; set; }
    }
}
