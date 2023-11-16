namespace University.Web.Models.ViewModels
{
    public class StudentDetailsViewModel
    {
	    public int Id { get; set; }
		public string Avatar { get; set; } = string.Empty;
		public string FirstName { get; set; }
		public string LastName { get; set; }
	    public string Email { get; set; } = string.Empty;
	    public int CourseCount { get; set; }
		//Nav prop
		public Address Address { get; set; } = new Address();
	    public IEnumerable<CourseInfo> CourseInfos { get; set; } = Enumerable.Empty<CourseInfo>();
	}
	public class CourseInfo
	{
		public int Id { get; set; }
		public int Grade { get; set; }
		public string CourseName { get; set; } = string.Empty;
	}
}
