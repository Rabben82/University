using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace University.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }

        //Nav prop
        public Address Address { get; set; }

        //Conv 2 samma som Conv 1
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Course>  Courses { get; set; }
    }
}
