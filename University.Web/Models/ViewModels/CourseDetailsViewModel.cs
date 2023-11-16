namespace University.Web.Models.ViewModels
{
	public class CourseDetailsViewModel
	{
		public int Id { get; set; }
		public IEnumerable<Student> Students { get; set; } = Enumerable.Empty<Student>();
	}
}
