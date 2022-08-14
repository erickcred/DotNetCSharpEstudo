using System;

namespace IniciandoDapper.Models
{
    public class CareerItem
    {
        public Guid CareerId { get; set; }
        public Course Course { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

    }
}