using System;
using System.Collections.Generic;

namespace IniciandoDapper.Models
{
    public class Career
    {
        public Career()
        {
            CareerItems = new List<CareerItem>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public int DurationInMinutes { get; set; }
        public bool Active { get; set; }
        public bool Featured { get; set; }
        public string Tags { get; set; }

        public IList<CareerItem> CareerItems { get; set; }
    }
}