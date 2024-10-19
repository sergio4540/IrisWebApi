using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTalentu.Models
{
    public class Categories
    {
        [Key]
        public int IdCategory { get; set; }
        public string NameCategory { get; set; }
    }
}
