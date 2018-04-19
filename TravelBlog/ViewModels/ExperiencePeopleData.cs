using System;
using System.Collections.Generic;
using TravelBlog.Models;


namespace TravelBlog.ViewModels
{
    public class ExperiencePeopleData
    {
        public ExperiencePeopleData()
        {
            public IEnumerable<Person> People { get; set; }
            public Experience Experience { get; set; }

        }
    }
}
