using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int ExperienceId { get; set; }
        //public ICollection<Experience> Experiences { get; set; }
        //public ICollection<Location> Locations { get; set; }
    }
}
