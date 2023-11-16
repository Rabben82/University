using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//#nullable disable

namespace University.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public Name Name { get; set; }

        public string Email { get; set; }

		//Nav prop
		public Address Address { get; set; } = new Address();

        //Conv 2 samma som Conv 1
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Course>  Courses { get; set; } = new List<Course>();

        private Student()
        {
            Avatar = null!;
            Name = null!;
            Email = null!;
        }

        public Student(string avatar, Name name, string email)
        {
            Avatar = avatar;
            Name = name;
            Email = email;
        }
    }
}
