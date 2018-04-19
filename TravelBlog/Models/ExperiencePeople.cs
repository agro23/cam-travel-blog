using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
    [Table("ExperiencePeople")]
    public class ExperiencePeople
    {
        [Key]
        public int ExperiencePeopleId { get; set; }
        public int ExperienceId { get; set; }
        public int PersonId { get; set; }
        public Experience Experience { get; set; }
        public Person Person { get; set; }

    
    }
}
