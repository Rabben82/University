using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace University.Core.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int Grade { get; set; }

        //Conv 1 nullable foreign key!!!!!!
        //public Student Student { get; set; }
    }
}
