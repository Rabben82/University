//#nullable disable

namespace University.Core.Entities
{
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        private Name()
        {
            FirstName = null!;
            LastName = null!;
        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
