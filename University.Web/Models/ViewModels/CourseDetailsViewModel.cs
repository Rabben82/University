namespace University.Web.Models.ViewModels
{
	public class CourseDetailsViewModel
	{
		public IEnumerable<Student> Students { get; set; } = Enumerable.Empty<Student>();
	}
}
