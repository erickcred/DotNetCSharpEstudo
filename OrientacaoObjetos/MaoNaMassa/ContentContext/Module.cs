using System.Collections.Generic;
using MaoNaMassa.SharedContext;

namespace MaoNaMassa.ContentContext
{
    public class Module : Base
    {
        public Module()
        {
            Lectures = new List<Lecture>();
        }

        public int Order { get; set; }
        public string Title { get; set; }
        public int Course { get; set; }
        public IList<Lecture> Lectures { get; set; }
    }

}