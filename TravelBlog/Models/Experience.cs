using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
    [Table("Experiences")]
    public class Experience
    {
        
        [Key]
        public int ExperienceId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Person> People { get; set; } 

    }
}
