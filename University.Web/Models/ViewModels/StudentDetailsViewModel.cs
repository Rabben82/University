namespace University.Web.Models.ViewModels
{
    public class StudentDetailsViewModel
    {
	    public int Id { get; set; }
		public string Avatar { get; set; } = string.Empty;
		public Name Name { get; set; } = default!;

	    public string Email { get; set; } = string.Empty;
		public int CourseCount => Courses?.Count ?? 0;

		//Nav prop
		public Address Address { get; set; } = new Address();

	    //Conv 2 samma som Conv 1
	    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
	    public ICollection<Course> Courses { get; set; } = new List<Course>();

	    public IEnumerable<CourseInfo> CourseInfos { get; set; } = Enumerable.Empty<CourseInfo>();
	}
	public class CourseInfo
	{
		public int Grade { get; set; }
		public string CourseName { get; set; } = string.Empty;
	}
}
